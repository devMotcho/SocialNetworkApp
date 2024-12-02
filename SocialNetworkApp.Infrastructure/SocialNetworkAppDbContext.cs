using Microsoft.EntityFrameworkCore;
using SocialNetworkApp.Domain.Models;

namespace SocialNetworkApp.Infrastructure
{
    public class SocialNetworkAppDbContext : DbContext
    {
        public SocialNetworkAppDbContext()
        {
        }
        public SocialNetworkAppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(true);
            optionsBuilder.UseSqlite($"Data Source=socialNetwork.db");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<TagPost> TagsPost { get; set; }


        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // User
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
            modelBuilder.Entity<User>() // Username Prop
                .Property(u => u.Username)
                .HasMaxLength(16)
                .IsRequired(true);
            modelBuilder.Entity<User>() // Password Prop
                .Property(u => u.Password)
                .HasMaxLength(32)
                .IsRequired(true);
            modelBuilder.Entity<User>() // IsAdmin Prop
                .Property(u => u.IsAdmin)
                .HasDefaultValue(false)
                .IsRequired(true);
            modelBuilder.Entity<User>() // 1-1 Required relationship with Profile
                .HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<Profile>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(false);

            // Profile
            modelBuilder.Entity<Profile>()
                .HasIndex(p => new { p.UserId })
                .IsUnique();
            modelBuilder.Entity<Profile>() // FirstName Prop
                .Property(p => p.FirstName)
                .HasMaxLength(45)
                .IsRequired(false);
            modelBuilder.Entity<Profile>() // LastName Prop
                .Property(p => p.LastName)
                .HasMaxLength(45)
                .IsRequired(false);
            modelBuilder.Entity<Profile>() // Description Prop
                .Property(p => p.Description)
                .HasMaxLength(256)
                .IsRequired(false);
            modelBuilder.Entity<Profile>()
                .Property(p => p.Avatar)
                .HasColumnType("BLOB")
                .IsRequired(false);

            // Posts
            modelBuilder.Entity<Post>()
                .HasIndex(p => new { p.Title, p.ProfileId })
                .IsUnique();
            modelBuilder.Entity<Post>() // Title Prop
                .Property(p => p.Title)
                .HasMaxLength(45)
                .IsRequired(true);
            modelBuilder.Entity<Post>() // Description Prop
                .Property(p => p.Description)
                .HasMaxLength(256)
                .IsRequired(true);
            modelBuilder.Entity<Post>() // N - 1 Required relationship with Profile
                .HasOne(p => p.Author)
                .WithMany(a => a.Posts)
                .HasForeignKey(p => p.ProfileId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);

            // Tags
            modelBuilder.Entity<Tag>()
                .HasIndex(t => new { t.Name })
                .IsUnique();
            modelBuilder.Entity<Tag>() // Name Prop
                .Property(t => t.Name)
                .HasMaxLength(45)
                .IsRequired(true);

            // TagsPosts
            modelBuilder.Entity<TagPost>()
                .HasIndex(tp => new { tp.PostId, tp.TagId })
                .IsUnique();
            modelBuilder.Entity<TagPost>() // N - 1 Relationship with Tag
                .HasOne(tp => tp.Tag)
                .WithMany(t => t.TagsPosts)
                .HasForeignKey(tp => tp.TagId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<TagPost>() // N - 1 Relationship With Post
                .HasOne(tp => tp.Post)
                .WithMany(p => p.TagsPosts)
                .HasForeignKey(tp => tp.PostId)
                .OnDelete(DeleteBehavior.Restrict);

            // Comment
            modelBuilder.Entity<Comment>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Comment>() // N - 1 Required Relationship with Profile
                .HasOne(c => c.Author)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.ProfileId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);
            modelBuilder.Entity<Comment>() // N - 1 Relationship with Post
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired(true);
            
            // Friendship
            modelBuilder.Entity<Friendship>()
                .HasIndex(f => new {f.FriendId, f.ProfileId})
                .IsUnique();
            modelBuilder.Entity<Friendship>() // Relationship with Profile as Profile Id
                .HasOne(fs  => fs.Profile)
                .WithMany(p => p.Friendships)
                .HasForeignKey(fs => fs.ProfileId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Friendship>() // Relationship with Profile as Friend Id
                .HasOne(fs => fs.Friend)
                .WithMany()
                .HasForeignKey(fs => fs.FriendId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>().HasData(
                    new User
                    {
                        Id = 1,
                        Username = "admin",
                        Password = "admin",
                        IsAdmin = true
                    });
            modelBuilder.Entity<Profile>().HasData(
                new Profile
                {
                    Id = 1,
                    UserId = 1,
                    FirstName = "Bernardo",
                    LastName = "Mamede",
                    Description = "O grande server admin, master of all masters.",
                    Avatar = null
                });
        }
    }
}

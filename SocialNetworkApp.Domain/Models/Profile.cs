using SocialNetworkApp.Domain.SeedWork;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SocialNetworkApp.Domain.Models
{
    public class Profile : Entity
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public byte[] Avatar { get; set; }

        public string FullName
        {
            get => FirstName + " " + LastName;
        }

        // Navigation Properties
        public virtual User User { get; set; }
        public virtual List<Friendship> Friendships { get; set; }
        public virtual List<Post> Posts { get; set; }
        public virtual List<Comment> Comments { get; set; }

        public Profile() { }

        public Profile(int userId, string firstName, string lastName, string description, byte[] avatar)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Description = description;
            Avatar = avatar;
        }

        public override string ToString()
        {
            return FullName;
        }
    }
}

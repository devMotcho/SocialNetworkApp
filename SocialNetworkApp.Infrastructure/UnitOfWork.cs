using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SocialNetworkApp.Domain;
using SocialNetworkApp.Domain.Repositories;
using SocialNetworkApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkApp.Infrastructure
{
    public class UnitOfWork : IUnityOfWork
    {
        DbContextOptions<SocialNetworkAppDbContext> _options;

        private SocialNetworkAppDbContext _dbContext;
        public UnitOfWork(DbContextOptions<SocialNetworkAppDbContext> options)
        {
            _options = options;
            _dbContext = new SocialNetworkAppDbContext(_options);
            _dbContext.Database.Migrate();
        }

        public UnitOfWork()
        {
            _dbContext = new SocialNetworkAppDbContext();
            _dbContext.Database.Migrate();
        }

        public ICommentRepository CommentRepository => new CommentRepository(_dbContext);

        public IFriendshipRepository FriendshipRepository => new FriendshipRepository(_dbContext);

        public IPostRepository PostRepository => new PostRepository(_dbContext);

        public IProfileRepository ProfileRepository => new ProfileRepository(_dbContext);

        public IUserRepository UserRepository => new UserRepository(_dbContext);

        public ITagRepository TagRepository => new TagRepository(_dbContext);

        public ITagPostRepository TagPostRepository => new TagPostRepository(_dbContext);

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void EnsureDelete()
        {
            _dbContext.Database.EnsureDeleted();
        }
    }
}

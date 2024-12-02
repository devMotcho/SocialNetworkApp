using Microsoft.EntityFrameworkCore;
using SocialNetworkApp.Domain.Models;
using SocialNetworkApp.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace SocialNetworkApp.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(SocialNetworkAppDbContext dbContext) : base(dbContext)
        {
        }

        public Task<User> FindByUsernameAndPasswordAsync(string username, string password)
        {
            return _dbContext.Users
                .Include(u => u.Profile)
                .SingleOrDefaultAsync( u => u.Username == username 
                && u.Password == password);
        }

        public Task<User> FindByUsernameAsync(string username)
        {
            return _dbContext.Users
                .Include(u => u.Profile)
                .SingleOrDefaultAsync(u => u.Username == username);
        }

        public override async Task<User> FindOrCreateAsync(User entity)
        {
            var instance = await _dbContext.Users
                .SingleOrDefaultAsync(u => u.Username == entity.Username);
            
            if (instance == null)
            {
                Create(entity);
                instance = entity;
            }
            return instance;
        }

        public override async Task<User> FindByIdAsync(int id)
        {
            return await _dbContext.Users
                .Include(u => u.Profile)
                .SingleOrDefaultAsync(u => u.Id == id);

        }
    }
}

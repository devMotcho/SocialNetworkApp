using SocialNetworkApp.Domain.Repositories;
using SocialNetworkApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace SocialNetworkApp.Infrastructure.Repositories
{
    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        public ProfileRepository(SocialNetworkAppDbContext dbContext) : base(dbContext)
        {
        }

        public Task<List<Profile>> GetAllProfilesByNameStartWithAsyc(string name)
        {
            return _dbContext.Profiles
                   .Include(p => p.User)
                   .Where(p => p.FullName.StartsWith(name))
                   .OrderBy(p => p.FullName)
                   .ToListAsync();
        }

        public override async Task<Profile> FindOrCreateAsync(Profile entity)
        {
            var instance = await _dbContext.Profiles
                .SingleOrDefaultAsync(p => p.UserId == entity.UserId);
            
            if (instance == null)
            {
                Create(entity);
                instance = entity;
            }
            return instance;
        }

        public override async Task<Profile> FindByIdAsync(int id)
        {
            return await _dbContext.Profiles
                .Include(p => p.User)
                .Include(p => p.Posts)
                    .ThenInclude(pst => pst.TagsPosts)
                    .ThenInclude(tp => tp.Tag)
                .Include(p => p.Friendships)
                .SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}

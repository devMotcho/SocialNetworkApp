using Microsoft.EntityFrameworkCore;
using SocialNetworkApp.Domain.Models;
using SocialNetworkApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkApp.Infrastructure.Repositories
{
    public class FriendshipRepository : Repository<Friendship>, IFriendshipRepository
    {
        public FriendshipRepository(SocialNetworkAppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Friendship>> FindAllFriendshipsByProfileIdAsync(int profileId)
        {
            return await _dbContext.Friendships
                .Include(fs => fs.Profile)
                    .ThenInclude(p => p.User)
                .Include(fs => fs.Friend)
                    .ThenInclude(f => f.User)
                .Where(f => f.ProfileId == profileId)
                .ToListAsync();
        }

        public override async Task<Friendship> FindOrCreateAsync(Friendship entity)
        {
            var instance = await _dbContext.Friendships
                .SingleOrDefaultAsync(
                fs => fs.FriendId == entity.FriendId &&
                fs.ProfileId == entity.ProfileId);
            if (instance == null)
            {
                Create(entity);
                instance = entity;
            }
            return instance;
        }
    }
}

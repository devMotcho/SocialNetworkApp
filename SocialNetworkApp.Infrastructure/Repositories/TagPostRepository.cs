using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialNetworkApp.Domain.Models;
using SocialNetworkApp.Domain.Repositories;

namespace SocialNetworkApp.Infrastructure.Repositories
{
    public class TagPostRepository : Repository<TagPost>, ITagPostRepository
    {
        public TagPostRepository(SocialNetworkAppDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<TagPost> FindOrCreateAsync(TagPost entity)
        {
            var instance = await _dbContext.TagsPost
                .SingleOrDefaultAsync(
                tp => tp.PostId == entity.PostId &&
                tp.TagId == entity.TagId
                );

            if (instance == null)
            {
                Create(entity);
                instance = entity;
            }
            return instance;
        }
    }
}

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialNetworkApp.Domain.Models;
using SocialNetworkApp.Domain.Repositories;

namespace SocialNetworkApp.Infrastructure.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(SocialNetworkAppDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Tag> FindOrCreateAsync(Tag entity)
        {
            var instance = await _dbContext.Tags
                .SingleOrDefaultAsync(t => t.Name == entity.Name);
            if (instance == null)
            {
                Create(entity);
                instance = entity;
            }
            return instance;
        }

        public Task<Tag> FindTagByNameAsync(string name)
        {
            return _dbContext.Tags
                .SingleOrDefaultAsync(t => t.Name == name);
        }
    }
}

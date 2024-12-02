using Microsoft.EntityFrameworkCore;
using SocialNetworkApp.Domain.Models;
using SocialNetworkApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetworkApp.Infrastructure.Repositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(SocialNetworkAppDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Post>> FindAllPostsByProfileIdAsync(int id)
        {
            return await _dbContext.Posts
                .Include(p => p.Author)
                    .ThenInclude(a => a.User)
                .Include(p => p.TagsPosts)
                    .ThenInclude(tp => tp.Tag)
                .Include(p => p.Comments)
                .Where(p => p.ProfileId == id)
                .OrderByDescending(p => p.PostedAt) // from the newest to the oldest 
                .ToListAsync();
        }

        public async Task<List<Post>> FindAllPostsByTitleStartingWithAsync(string title)
        {
            return await _dbContext.Posts
                .Include(p => p.Author)
                    .ThenInclude(a => a.User)
                .Include(p => p.TagsPosts)
                    .ThenInclude(p => p.Tag)
                .Include(p => p.Comments)
                .Where(p => p.Title.StartsWith(title))
                .OrderBy(p => p.Title)
                .ToListAsync();
        }

        public override async Task<Post> FindOrCreateAsync(Post entity)
        {
            var instance = await _dbContext.Posts
                .SingleOrDefaultAsync(p => p.Title == entity.Title);

            if (instance == null)
            {
                entity.PostedAt = DateTime.Now;
                Create(entity);
                instance = entity;
            }
            return instance;
        }

        public override async Task<Post> FindByIdAsync(int id)
        {
            return await _dbContext.Posts
                .Include(p => p.Author)
                    .ThenInclude(a => a.User)
                .Include(p => p.TagsPosts)
                    .ThenInclude(p => p.Tag)
                .Include(p => p.Comments)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public Task<Post> FindByTitle(string title)
        {
            return _dbContext.Posts
                .Include(p => p.Author)
                    .ThenInclude(a => a.User)
                .Include(p => p.TagsPosts)
                    .ThenInclude(p => p.Tag)
                .Include(p => p.Comments)
                .SingleOrDefaultAsync(p => p.Title ==  title);
        }

        public override async Task<List<Post>> FindAllAsync()
        {
            return await _dbContext.Posts
                .Include(p => p.Author)
                    .ThenInclude(a => a.User)
                .Include(p => p.TagsPosts)
                    .ThenInclude(p => p.Tag)
                .Include(p => p.Comments)
                .ToListAsync();
        }
    }
}

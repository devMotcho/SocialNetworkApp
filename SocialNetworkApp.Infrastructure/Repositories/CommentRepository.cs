using Microsoft.EntityFrameworkCore;
using SocialNetworkApp.Domain.Models;
using SocialNetworkApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkApp.Infrastructure.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(SocialNetworkAppDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Comment>> FindAllCommentsByPostIdAsync(int postId)
        {
            return await _dbContext.Comments
                .Include(c => c.Author)
                    .ThenInclude(a => a.User)
                .Include(c => c.Post)
                .Where(c => c.PostId == postId)
                .OrderByDescending(c => c.CommentedAt)
                .ToListAsync();
        }

        public override async Task<Comment> FindOrCreateAsync(Comment entity)
        {
            var instance = await _dbContext.Comments
                .SingleOrDefaultAsync(c =>
                    c.ProfileId == entity.ProfileId &&
                    c.PostId == entity.PostId &&
                    c.Content == entity.Content);

            if (instance == null)
            {
                var postExists = await _dbContext.Posts.AnyAsync(p => p.Id == entity.PostId);
                var profileExists = await _dbContext.Profiles.AnyAsync(p => p.Id == entity.ProfileId);

                if (!postExists || !profileExists)
                {
                    throw new InvalidOperationException("Post or Profile does not exist.");
                }

                entity.CommentedAt = DateTime.Now;
                Create(entity);
                instance = entity;
            }

            return instance;
        }
    }

    }


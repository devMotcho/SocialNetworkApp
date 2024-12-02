using SocialNetworkApp.Domain.Models;
using SocialNetworkApp.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SocialNetworkApp.Domain.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<List<Comment>> FindAllCommentsByPostIdAsync(int postId);
    }
}

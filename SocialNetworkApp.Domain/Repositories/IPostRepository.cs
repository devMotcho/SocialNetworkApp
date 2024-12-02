using SocialNetworkApp.Domain.Models;
using SocialNetworkApp.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetworkApp.Domain.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<Post> FindByTitle(string title);
        Task<List<Post>> FindAllPostsByProfileIdAsync(int id);
        Task<List<Post>> FindAllPostsByTitleStartingWithAsync(string title);
    }
}

using SocialNetworkApp.Domain.Models;
using SocialNetworkApp.Domain.SeedWork;
using System.Threading.Tasks;

namespace SocialNetworkApp.Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindByUsernameAndPasswordAsync(string username, string password);
        Task<User> FindByUsernameAsync(string username);
    }
}

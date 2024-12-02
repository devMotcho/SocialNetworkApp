using SocialNetworkApp.Domain.Models;
using SocialNetworkApp.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetworkApp.Domain.Repositories
{
    public interface ITagRepository : IRepository<Tag>
    {
        Task<Tag> FindTagByNameAsync(string name);
    }
}

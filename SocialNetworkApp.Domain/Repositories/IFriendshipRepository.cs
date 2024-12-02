using SocialNetworkApp.Domain.Models;
using SocialNetworkApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkApp.Domain.Repositories
{
    public interface IFriendshipRepository : IRepository<Friendship>
    {
        Task<List<Friendship>> FindAllFriendshipsByProfileIdAsync(int profileId);
    }
}

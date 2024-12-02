using SocialNetworkApp.Domain.SeedWork;

namespace SocialNetworkApp.Domain.Models
{
    public class Friendship : Entity
    {
        public Friendship(int profileId, int friendId)
        {
            ProfileId = profileId;
            FriendId = friendId;
        }
        public Friendship() { }

        public int ProfileId { get; set; }
        public int FriendId { get; set; }

        // Navigation Properties
        public virtual Profile Profile { get; set; }
        public virtual Profile Friend { get; set; }
    }
}

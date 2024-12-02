using SocialNetworkApp.Domain.SeedWork;
using System;

namespace SocialNetworkApp.Domain.Models
{
    public class Comment : Entity
    {
        public int ProfileId { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CommentedAt { get; set; } = new DateTime();

        // Navigation Properties
        public virtual Post Post { get; set; }
        public virtual Profile Author { get; set; }

        public Comment() { }
        public Comment(int profileId, int postId, string content)
        {
            ProfileId = profileId;
            PostId = postId;
            Content = content;
        }

    }
}

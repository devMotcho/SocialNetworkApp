using SocialNetworkApp.Domain.SeedWork;
using System;
using System.Collections.Generic;

namespace SocialNetworkApp.Domain.Models
{
    public class Post : Entity
    {
        public int ProfileId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime PostedAt { get; set; } = new DateTime();

        // Navigation Properties
        public virtual Profile Author { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<TagPost> TagsPosts { get; set; }

        public Post() {}

        public Post(int profileId, string title, string description)
        {
            ProfileId = profileId;
            Title = title;
            Description = description;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}

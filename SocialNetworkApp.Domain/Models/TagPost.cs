using SocialNetworkApp.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetworkApp.Domain.Models
{
    public class TagPost : Entity
    {
        public int PostId { get; set; }
        public int TagId { get; set; }
        
        // Navigation Properties
        public virtual Post Post { get; set; }
        public virtual Tag Tag { get; set; }
    
        public TagPost(int postId, int tagId)
        {
            PostId = postId;
            TagId = tagId;
        }
        
        public TagPost()
        {

        }
    }
}

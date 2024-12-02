using SocialNetworkApp.Domain.SeedWork;
using System.Collections.Generic;

namespace SocialNetworkApp.Domain.Models
{
    public class Tag : Entity
    {
        public string Name { get; set; } = string.Empty;

        // Navigation Properties
        public virtual List<TagPost> TagsPosts { get; set; }

        public Tag(string name) 
        {
            Name = name;
        }
        public Tag()
        {
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

using SocialNetworkApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkApp.Console
{
    public class SeedData
    {
        public List<Post> PostList { get; private set; }
        public List<Tag> TagList { get; private set; }
        public List<TagPost> TagPostList { get; private set; }
        public List<Comment> CommentList { get; private set; }
        public List<User> UserList { get; private set; }
        public List<Profile> ProfileList { get; private set; }

        public List<Friendship> Friendships { get; private set; }

        public SeedData()
        {
            // Initialize Posts
            PostList = new List<Post>
            {
                new Post (1, "Testing", "Hello World, Hello Social Networking App"),
                new Post (1, "Testing 2.", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book."),
                new Post (1, "Testing 3", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book."),
                new Post (1, "Testing 4", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s."),
            };

            // Initialize Tags
            TagList = new List<Tag>
            {
                new Tag("Test"),
                new Tag("Programming"),
                new Tag("Backend"),
            };

            // Initialize TagPosts
            TagPostList = new List<TagPost>
            {
                new TagPost(1,1),
                new TagPost(2,1),
                new TagPost(3,1),
            };

            CommentList = new List<Comment>
            {
                new Comment(1, 1, "Hello World!"),
                new Comment(1, 1, "Hello World tem um significado profundo na programação."),
            };

            UserList = new List<User>
            {
                new User("bernardo", "bernardo", true),
                new User("outro", "outro", false),
            };

            ProfileList = new List<Profile>
            {
                new Profile(2, "Bernardo", "Fernandes", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", null),
                new Profile(3, "Judite", "Soares", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", null),
            };

            Friendships = new List<Friendship>
            {
                new Friendship(2, 1),
                new Friendship(2, 3),
            };
        }
    }

}

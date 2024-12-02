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
                new Post (1, "O aluno a36919 merece um 20.", "Este post serve apenas para dizer que o aluno merece um 20 a DA."),
                new Post (1, "As aulas de DA são uteis", "Acredito que as aulas de DA são uteis para o futuro dos alunos."),
                new Post (1, "Test", "Hello testing"),
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
                new Comment(1, 1, "Hello World é tem um significado profundo na programação."),
            };

            UserList = new List<User>
            {
                new User("bernardo", "bernardo", true),
                new User("outro", "outro", false),
            };

            ProfileList = new List<Profile>
            {
                new Profile(2, "Bernardo", "Fernandes", "Um belo moço", null),
                new Profile(3, "Outro", "Macaco", "Um belo macaco", null),
            };

            Friendships = new List<Friendship>
            {
                new Friendship(2, 1),
                new Friendship(2, 3),
            };
        }
    }

}

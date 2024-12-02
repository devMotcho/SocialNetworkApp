using SocialNetworkApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkApp.Domain
{
    public interface IUnityOfWork : IDisposable
    {
        ICommentRepository CommentRepository { get; }
        IFriendshipRepository FriendshipRepository { get; }
        IPostRepository PostRepository { get; }
        IProfileRepository ProfileRepository { get; }
        IUserRepository UserRepository { get; }
        ITagRepository TagRepository { get; }
        ITagPostRepository TagPostRepository { get; }
        Task SaveAsync();
    }
}

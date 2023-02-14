using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Application.Interfaces;
public interface IPostRepository : IBaseRepo<Post>
{
 Task<Post> AddPostWithUser(Post post, User user);
}
using BusinessLogic.Domain;
using CommonGenericClasses;
using System.Linq.Expressions;

namespace BusinessLogic.Application.Interfaces;
public interface IPostRepository : IBaseRepo<Post>
{
    Task<Post> AddPostWithUser(Post post, User user);
    Task<Post> DeletePostWithUser(Post Post, User user);

    Task<Post> UpdatePostWithUser(Post Post, User user);


    Task<Post> GetPostAsync(Expression<Func<Post, bool>> predicate);
    }
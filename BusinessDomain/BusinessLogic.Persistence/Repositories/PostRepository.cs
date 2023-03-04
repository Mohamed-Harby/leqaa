using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BusinessLogic.Persistence.Repositories;

public class PostRepository : BaseRepo<Post>, IPostRepository
{


    private readonly ApplicationDbContext _context;
    public PostRepository(ApplicationDbContext context) : base(context)
    {

        _context = context;
    }

    public async Task<Post> AddPostWithUser(Post post, User user)
    {
        post.AddUser(user);
        await db.Set<Post>().AddAsync(post);
        return post;
    }

    public Task<Post> DeletePostWithUser(Post Post, User user)
    {
        throw new NotImplementedException();
    }


    public async Task<Post> GetPostAsync(Expression<Func<Post, bool>> predicate)
    {
        var post = await db.Set<Post>().FirstOrDefaultAsync(predicate);
        return post;
    }

    public Task<Post> UpdatePostWithUser(Post Post, User user)
    {
        throw new NotImplementedException();


    }


}

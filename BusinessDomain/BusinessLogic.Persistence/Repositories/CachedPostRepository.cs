using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Linq.Expressions;

namespace BusinessLogic.Persistence.Repositories;

public class CachedPostRepository : BaseCachedRepo<Post>, IPostRepository
{


    private readonly ApplicationDbContext _context;
    private readonly IDistributedCache _distributedCache;
    public CachedPostRepository(ApplicationDbContext context,IDistributedCache distributedCache) : base(context,distributedCache)
    {

        _context = context;
        _distributedCache= distributedCache;
    }

    public async Task<Post> AddPostWithUser(Post post, User user)
    {
        post.SetUser(user);
        await _db.Set<Post>().AddAsync(post);
        return post;
    }

    public Task<Post> DeletePostWithUser(Post Post, User user)
    {
        throw new NotImplementedException();
    }


    public async Task<Post> GetPostAsync(Expression<Func<Post, bool>> predicate)
    {
        var post = await _db.Set<Post>().FirstOrDefaultAsync(predicate);
        return post ?? new Post();
    }

    public Task<Post> UpdatePostWithUser(Post Post, User user)
    {
        throw new NotImplementedException();


    }


}

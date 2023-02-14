using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Persistence.Repositories;

public class PostRepository : BaseRepo<Post>, IPostRepository
{


    private readonly ApplicationDbContext _context;
    public PostRepository(ApplicationDbContext context) : base(context)
    {

        _context = context;
    }

    public Task<Post> AddPostWithUser(Post post, User user)
    {
        throw new NotImplementedException();
    }

    public Task<Post> DeletePostWithUser(Post Post, User user)
    {
        throw new NotImplementedException();
    }

    public Task<Post> UpdatePostWithUser(Post Post, User user)
    {
        throw new NotImplementedException();

        
    }


}

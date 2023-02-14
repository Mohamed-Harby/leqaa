using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Persistence.Repositories
{
    public class PostRepository : BaseRepo<Post>, IPostRepository
    {
        public PostRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Post> AddPostWithUser(Post post, User user)
        {

            post.User = user;
            await db.Set<Post>().AddAsync(post);
            return post;
                }
    }


}
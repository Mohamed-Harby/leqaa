using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Persistence.Repositories;

public class UserPinnedPostRepository : BaseRepo<UserPinnedPost>,IUserPinnedPostRepository
{


    private readonly ApplicationDbContext _context;
    public UserPinnedPostRepository(ApplicationDbContext context) : base(context)
    {

        _context = context;
    }

    
}

using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Persistence.Repositories;

public class UserPinnedHubRepository : BaseRepo<UserPinnedHub>, IUserPinnedHubRepository
{


    private readonly ApplicationDbContext _context;
    public UserPinnedHubRepository(ApplicationDbContext context) : base(context)
    {

        _context = context;
    }

    
}

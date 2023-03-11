using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Persistence.Repositories;

public class UserPinnedChannelRepository : BaseRepo<UserPinnedChannel>,IUserPinnedChannelRepository
{


    private readonly ApplicationDbContext _context;
    public UserPinnedChannelRepository(ApplicationDbContext context) : base(context)
    {

        _context = context;
    }

    
}

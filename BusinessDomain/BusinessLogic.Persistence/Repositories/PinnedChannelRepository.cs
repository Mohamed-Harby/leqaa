using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Persistence.Repositories;

public class PinnedChannelRepository : BaseRepo<PinnedChannel>, IPinnedChannelRepository
{


    private readonly ApplicationDbContext _context;
    public PinnedChannelRepository(ApplicationDbContext context) : base(context)
    {

        _context = context;
    }

    
}

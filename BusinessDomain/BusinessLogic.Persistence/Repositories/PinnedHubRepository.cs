using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Persistence.Repositories;

public class PinnedHubRepository : BaseRepo<PinnedHub>, IPinnedHubRepository
{


    private readonly ApplicationDbContext _context;
    public PinnedHubRepository(ApplicationDbContext context) : base(context)
    {

        _context = context;
    }

    
}

using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Persistence.Repositories;

public class PinnedPostRepository : BaseRepo<PinnedPost>, IPinnedPostRepository
{


    private readonly ApplicationDbContext _context;
    public PinnedPostRepository(ApplicationDbContext context) : base(context)
    {

        _context = context;
    }

    
}

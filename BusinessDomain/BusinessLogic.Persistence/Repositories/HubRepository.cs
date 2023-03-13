using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Persistence.Repositories;
public class HubRepository : BaseRepo<Hub>, IHubRepository
{
    private readonly ApplicationDbContext _context;
    public HubRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}
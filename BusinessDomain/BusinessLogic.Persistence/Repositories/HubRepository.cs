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
    public async Task<Hub> AddHubWithUserAsync(Hub hub, User user)
    {
        hub.AddUser(user);
        await table.AddAsync(hub);
        return hub;
    }

    public Task<Hub> DeleteHubWithUserAsync(Hub hub, User user)
    {
        throw new NotImplementedException();
    }

    public Task<Hub> UpdateHubWithUserAsync(Hub hub, User user)
    {
        throw new NotImplementedException();
    }
}
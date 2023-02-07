using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Persistence.Repositories;
public class HubRepository : BaseRepo<Hub>, IHubRepository
{
    public HubRepository(ApplicationDbContext context) : base(context)
    {
    }
    public async Task<Hub> AddHubWithUserAsync(Hub hub, User user)
    {
        hub.AddUser(user);
        await db.Set<Hub>().AddAsync(hub);
        return hub;
    }
}
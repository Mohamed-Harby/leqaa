using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Application.Interfaces;
public interface IHubRepository : IBaseRepo<Hub>
{
    Task<Hub> AddHubWithUserAsync(Hub hub, User user);

}
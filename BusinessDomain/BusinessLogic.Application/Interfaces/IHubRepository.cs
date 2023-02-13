using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Application.Interfaces;
public interface IHubRepository : IBaseRepo<Hub>
{
    Task<Hub> AddHubWithUserAsync(Hub hub, User user);
    Task<Hub> UpdateHubWithUserAsync(Hub hub, User user);
    Task<Hub> DeleteHubWithUserAsync(Hub hub, User user);


}
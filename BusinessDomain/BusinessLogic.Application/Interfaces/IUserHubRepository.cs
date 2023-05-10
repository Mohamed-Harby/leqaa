using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Application.Interfaces;
public interface IUserHubRepository : IBaseRepo<UserHub>
{
    void ChangeStateToAdded(UserHub userHub);

}
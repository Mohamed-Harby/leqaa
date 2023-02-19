using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Application.Interfaces;
public interface IUserRepository : IBaseRepo<User>
{
    public Task<User> GetUserWithRooms(string username);

}
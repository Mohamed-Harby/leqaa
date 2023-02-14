using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Persistence.Repositories;
public interface IUserRepository : IBaseRepo<User>
{
    public Task<User> GetUserWithRooms(string username);

}
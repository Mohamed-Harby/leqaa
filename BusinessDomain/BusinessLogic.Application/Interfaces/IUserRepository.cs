using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Application.Interfaces;
public interface IUserRepository : IBaseRepo<User>
{
    public Task<User> GetUserWithRoomsAsync(string username);
    public Task<User?> GetUserWithPlansAsync(string username);
    public Task<User?> GetUserWithPlansWithHubsAsync(string username);
    public Task<User?> GetUserWithPlansWithChannelsAsync(string username);
    public Task<User?> GetUserWithPlansWithChannelsWithHubsAsync(string username);


    public Task<User> GetUserWithHubsAsync(string username);

}
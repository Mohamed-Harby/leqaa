using BusinessLogic.Domain;
using CommonGenericClasses;
using System.Linq.Expressions;

namespace BusinessLogic.Application.Interfaces;
public interface IUserRepository : IBaseRepo<User>
{

    public Task<User> GetUserAsync(Expression<Func<User, bool>> predicate = null!, string include = "");
    public Task<User> GetUserWithRoomsAsync(string username);
    public Task<User?> GetUserWithPlansAsync(string username);
    public Task<User?> GetUserWithPlansWithHubsAsync(string username);
    public Task<User?> GetUserWithPlansWithChannelsAsync(string username);
public Task<User?> GetUserWithChannelsIncludingAnnouncements(string username);


    public Task<User> GetUserWithHubsAsync(string username);

}
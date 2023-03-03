using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BusinessLogic.Persistence.Repositories;
public class UserRepository : BaseRepo<User>, IUserRepository
{
    private readonly ApplicationDbContext _context;
   
    public UserRepository(ApplicationDbContext context) : base(context)
    {

        _context = context;
    }

    public async Task<User> GetUserWithHubsAsync(string username)
    {
        User user = (await table.Where(u => u.UserName == username).Include(u => u.Hubs).FirstOrDefaultAsync())!;
        return user;
    }

    public async Task<User?> GetUserWithPlansAsync(string username)
    {
        User? user = (await table.Where(u => u.UserName == username).AsNoTracking().Include(u => u.Plans).FirstOrDefaultAsync());
        return user;
    }

    public async Task<User?> GetUserWithPlansWithChannelsAsync(string username)
    {
        User? user = (
            await table
            .Where(u => u.UserName == username)
            .AsNoTracking()
            .Include(u => u.Plans)
            .Include(u => u.Channels)
            .AsSplitQuery()
            .FirstOrDefaultAsync());
        return user;
    }

    public Task<User?> GetUserWithPlansWithChannelsWithHubsAsync(string username)
    {
        var userTask = (
             table
            .Where(u => u.UserName == username)
            .AsNoTracking()
            .Include(u => u.Plans)
            .Include(u => u.Channels)
            .Include(u => u.Hubs)
            .AsSplitQuery()
            .FirstOrDefaultAsync());
        return userTask;
    }

    public async Task<User?> GetUserWithPlansWithHubsAsync(string username)
    {
        var user = await GetAsync(u => u.UserName == username, null!, "Plans,Hubs");
        // User? user = (
        //      table
        //     .Where(u => u.UserName == username)
        //     .AsNoTracking()
        //     .Include(u => u.Plans)
        //     .Include(u => u.Hubs)
        //     .AsSplitQuery()
        //     .AsParallel()
        //     .FirstOrDefault());
        return await user.FirstOrDefaultAsync();
    }

    public async Task<User> GetUserWithRoomsAsync(string username)
    {
        User user = (await table.Where(u => u.UserName == username).Include(u => u.Rooms).FirstOrDefaultAsync())!;
        return user;

    }


    public async Task<User> GetUserAsync(Expression<Func<User, bool>> predicate = null, string include = "")

    {
        User user = (await table.Where(predicate).Include(include).FirstOrDefaultAsync())!;
        return user;

    }
}
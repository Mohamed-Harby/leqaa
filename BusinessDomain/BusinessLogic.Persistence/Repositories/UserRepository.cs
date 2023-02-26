using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore;

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

    public Task<User?> GetUserWithPlansWithHubsAsync(string username)
    {
        User? user = (
             table
            .Where(u => u.UserName == username)
            .AsNoTracking()
            .Include(u => u.Plans)
            .Include(u => u.Hubs)
            .AsSplitQuery()
            .AsParallel()
            .FirstOrDefault());
        return Task.FromResult(user);
    }

    public async Task<User> GetUserWithRoomsAsync(string username)
    {
        User user = (await table.Where(u => u.UserName == username).Include(u => u.Rooms).FirstOrDefaultAsync())!;
        return user;

    }
}
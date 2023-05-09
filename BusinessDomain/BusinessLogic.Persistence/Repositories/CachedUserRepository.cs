using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Linq.Expressions;

namespace BusinessLogic.Persistence.Repositories;
public class CachedUserRepository : BaseCachedRepo<User>, IUserRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IDistributedCache _distributedCache;

    public CachedUserRepository(ApplicationDbContext context,IDistributedCache distributedCache) : base(context, distributedCache)
    {

        _context = context;
        _distributedCache = distributedCache;
    }

    public async Task<User> GetUserWithHubsAsync(string username)
    {
        User user = (await _table.Where(u => u.UserName == username).Include(u => u.Hubs).FirstOrDefaultAsync())!;
        return user;
    }

    public async Task<User?> GetUserWithPlansAsync(string username)
    {
        User? user = (await _table.Where(u => u.UserName == username).AsNoTracking().Include(u => u.Plans).FirstOrDefaultAsync());
        return user;
    }

    public async Task<User?> GetUserWithPlansWithChannelsAsync(string username)
    {
        User? user = (
            await _table
            .Where(u => u.UserName == username)
            .AsNoTracking()
            .Include(u => u.Plans)
            .Include(u => u.Channels)
            .AsSplitQuery()
            .FirstOrDefaultAsync());
        return user;
    }



    public async Task<User?> GetUserWithPlansWithHubsAsync(string username)
    {
        var user = await GetAsync(u => u.UserName == username, null!, "Plans,Hubs");
        return await user.FirstOrDefaultAsync();
    }

    public async Task<User> GetUserWithRoomsAsync(string username)
    {
        User user = (await _table.Where(u => u.UserName == username).Include(u => u.Rooms).FirstOrDefaultAsync())!;
        return user;

    }
    public async Task<User> GetUserAsync(Expression<Func<User, bool>> predicate = null!, string include = "")

    {
        User user = (await _table.Where(predicate).Include(include).FirstOrDefaultAsync())!;
        return user;

    }

    public async Task<User?> GetUserWithChannelsIncludingAnnouncements(string username)
    {
        User user = (await _table
        .Where(u => u.UserName == username)
        .Include(u => u.Channels)
        .ThenInclude(c => c.ChannelAnnouncements.OrderByDescending(a => a.CreationDate))
        .FirstOrDefaultAsync())!;
        return user;
    }
}
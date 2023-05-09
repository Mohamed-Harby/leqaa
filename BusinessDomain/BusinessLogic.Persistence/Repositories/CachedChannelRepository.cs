using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using BusinessLogic.Domain.Common;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;

namespace BusinessLogic.Persistence.Repositories;

public class CachedChannelRepository : BaseCachedRepo<Channel>, IChannelRepository
{

    private readonly IDistributedCache _distributedCache;
    private readonly ApplicationDbContext _context;
    public CachedChannelRepository(ApplicationDbContext context, IDistributedCache distributedCache) : base(context, distributedCache)
    {
        

        _context = context;
        _distributedCache = distributedCache;
    }
    public async Task<List<BaseEntity>> GetRecentActivitiesAsync(Guid id, int pageNumber, int pageSize)
    {
        var channel = (await _context.Set<Channel>()
                                    .Where(c => c.Id == id)
                                    .Include(c => c.JoinedUsers)
                                    .Include(c => c.ChannelAnnouncements)
                                    .FirstOrDefaultAsync())!;
        var recentActivities = new List<BaseEntity>();
        recentActivities.AddRange(channel.JoinedUsers);
        recentActivities.AddRange(channel.ChannelAnnouncements);
        recentActivities = recentActivities.OrderByDescending(b => b.CreationDate).ToList();
        return recentActivities;


    }

    public Task<Channel> DeleteChannelWithUser(Channel channel, User user)
    {
        throw new NotImplementedException();
    }



    public Task<Channel> UpdateChannelWithUser(Channel channel, User user)
    {
        throw new NotImplementedException();
    }


}

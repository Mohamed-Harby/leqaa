using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Persistence.Repositories;

public class ChannelRepository : BaseRepo<Channel>, IChannelRepository
{


    private readonly ApplicationDbContext _context;
    public ChannelRepository(ApplicationDbContext context) : base(context)
    {

        _context = context;
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

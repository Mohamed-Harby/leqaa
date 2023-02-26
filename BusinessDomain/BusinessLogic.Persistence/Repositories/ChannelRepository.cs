using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Persistence.Repositories;

public class ChannelRepository : BaseRepo<Channel>, IChannelRepository
{


    private readonly ApplicationDbContext _context;
    public ChannelRepository(ApplicationDbContext context) : base(context)
    {

        _context = context;
    }
    public async Task<Channel> AddChannelWithUser(Channel channel, User user)
    {
        channel.AddUser(user);
        await db.Set<Channel>().AddAsync(channel);
        return channel;
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

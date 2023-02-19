using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Application.Interfaces;
public interface IChannelRepository : IBaseRepo<Channel>
{
    Task<Channel> AddChannelWithUser(Channel channel, User user);
    Task DeleteChannel(Channel channel);

    

    Task<Channel> DeleteChannelWithUser(Channel channel, User user);

    Task<Channel> UpdateChannelWithUser(Channel channel, User user);
}
using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Application.Interfaces;
public interface IChannelRepository : IBaseRepo<Channel>
{
    Task<Channel> AddChannelWithUser(Channel channel, User user);
<<<<<<< HEAD
    Task DeleteChannel(Channel channel);

    
=======
    Task<Channel> DeleteChannelWithUser(Channel channel, User user);
>>>>>>> cd65d9bef45cdce8006c7353066b595fe454f625

    Task<Channel> UpdateChannelWithUser(Channel channel, User user);
}
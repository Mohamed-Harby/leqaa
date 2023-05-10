using BusinessLogic.Domain;
using BusinessLogic.Domain.Common;
using CommonGenericClasses;

namespace BusinessLogic.Application.Interfaces;
public interface IChannelRepository : IBaseRepo<Channel>
{
    Task<List<BaseEntity>> GetRecentActivitiesAsync(Guid id, int pageNumber, int pageSize);
    Task<Channel> DeleteChannelWithUser(Channel channel, User user);
    Task<Channel> UpdateChannelWithUser(Channel channel, User user);




}
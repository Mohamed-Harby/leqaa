using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using BusinessLogic.Domain.Common;

namespace BusinessLogic.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task<Hub> CreateHubAsync(Hub hubToBeCreated, User creator);
        Task<Channel> CreateChannelAsync(Channel channelToBeCreated, User creator);
        Task<Room> CreateRoomAsync(Room roomToBeCreated, User creator);
        Task<HubAnnouncement> CreateHubAnnoucementAsync(HubAnnouncement hubToBeCreated, User creator);

        Task<Hub> PinHubAsync(Hub hub, User User);
        Task<Channel> PinChannelAsync(Channel channel, User creator);
        Task<Post> PinPostAsync(Post post, User creator);
        Task<User> useruser(User Followed, User Follower);
        Task<ChannelAnnouncement> CreateChannelAnnoucementAsync(ChannelAnnouncement hubToBeCreated, User creator);
        Task<List<BaseEntity>> GetRecentActivitiesAsync(int pageNumber, int pageSize);
        Task<List<BaseEntity>> GetUserRecentActivitiesAsync(string userName, int pageNumber, int pageSize);


        Task<int> SaveAsync(CancellationToken cancellationToken = default);
    }
}
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;

namespace BusinessLogic.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task<Hub> CreateHubAsync(Hub hubToBeCreated, User creator);
        Task<Channel> CreateChannelAsync(Channel channelToBeCreated, User creator);
        Task<Room> CreateRoomAsync(Room roomToBeCreated, User creator);
        Task<HubAnnouncement> CreateHubAnnoucementAsync(HubAnnouncement hubToBeCreated, User creator);

        Task<ChannelAnnouncement> CreateChannelAnnoucementAsync(ChannelAnnouncement hubToBeCreated, User creator);

        Task<int> Save();
    }
}
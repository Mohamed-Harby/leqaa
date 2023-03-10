using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using BusinessLogic.Domain.SharedEnums;
using BusinessLogic.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Persistence.UnitsOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private ApplicationDbContext _context;
    public UnitOfWork(ApplicationDbContext context)

    {
        _context = context;
    }
    public async Task<int> Save()
    {
        //returns how many rows were affected
        return await _context.SaveChangesAsync();
    }

    public async void Dispose()
    {
        await _context.DisposeAsync();
    }

    public Task<Hub> CreateHubAsync(Hub hubToBeCreated, User creator)
    {
        var userHub = new UserHub
        {
            User = creator,
            Hub = hubToBeCreated,
            Role = GroupRole.Founder
        };

        creator.Hubs.Add(hubToBeCreated);

        _context.Set<UserHub>().Update(userHub);

        return Task.FromResult(hubToBeCreated);
    }

    public Task<HubAnnouncement> CreateHubAnnoucementAsync(HubAnnouncement hubToBeCreated, User creator)
    {
        var userHub = new UserHubAnnouncement
        {
            User = creator,
            HubAnnouncement = hubToBeCreated,

        };

        creator.HubAnnouncements.Add(hubToBeCreated);

        _context.Set<UserHubAnnouncement>().Update(userHub);

        return Task.FromResult(hubToBeCreated);
    }

    public Task<ChannelAnnouncement> CreateChannelAnnoucementAsync(ChannelAnnouncement hubToBeCreated, User creator)
    {
        var userHub = new UserChannelAnnoucement
        {
            User = creator,
           ChannelAnnouncement= hubToBeCreated

        };

        creator.ChannelAnnouncement.Add(hubToBeCreated);

        _context.Set<UserChannelAnnoucement>().Update(userHub);

        return Task.FromResult(hubToBeCreated);
    }

    public Task<Channel> CreateChannelAsync(Channel channelToBeCreated, User creator)
    {
        var userChannel = new UserChannel
        {
            Channel = channelToBeCreated,
            User = creator,
            Role = GroupRole.Founder
        };
        creator.Channels.Add(channelToBeCreated);
        _context.Set<UserChannel>().Update(userChannel);
        return Task.FromResult(channelToBeCreated);
    }

    public Task<Room> CreateRoomAsync(Room roomToBeCreated, User creator)
    {
        var userRoom = new UserRoom
        {
            Room = roomToBeCreated,
            User = creator,
            Role = GroupRole.Founder
        };
        creator.Rooms.Add(roomToBeCreated);
        _context.Set<UserRoom>().Update(userRoom);
        return Task.FromResult(roomToBeCreated);
    }


}
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using BusinessLogic.Domain.SharedEnums;
using BusinessLogic.Persistence.Repositories;
using BusinessLogic.Application.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BusinessLogic.Persistence.UnitsOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private ApplicationDbContext _context;
    private readonly IUserRepository _userRepository;
    public UnitOfWork(ApplicationDbContext context, IUserRepository userRepository)

    {
        _context = context;
        _userRepository = userRepository;
    }
    public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
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
            ChannelAnnouncement = hubToBeCreated

        };

        creator.ChannelAnnouncements.Add(hubToBeCreated);

        _context.Set<UserChannelAnnoucement>().Update(userHub);

        return Task.FromResult(hubToBeCreated);
    }






    




    public Task<Hub> PinHubAsync(Hub hub, User User)
    {
        var userPinndHub = new UserPinnedHub
        {
            UserPinned = User,
            PinnedHub = hub
        };
        User.PinnedHubs.Add(hub);
        _context.Set<UserPinnedHub>().Update(userPinndHub);

        return Task.FromResult(hub);

    }



    public Task<Channel> PinChannelAsync(Channel channel, User creator)
    {
        var userPinndChannel = new UserPinnedChannel
        {
            UserPinned = creator,
            PinnedChannel = channel

        };
        creator.PinnedChannels.Add(channel);

        _context.Set<UserPinnedChannel>().Update(userPinndChannel);

        return Task.FromResult(channel);
    }
    public Task<Post> PinPostAsync(Post post, User creator)
    {
        var userPinnedPost = new UserPinnedPost
        {
            UserPinned = creator,
            PinnedPost = post
        };

        creator.PinnedPosts.Add(post);

        _context.Set<UserPinnedPost>().Update(userPinnedPost);

        return Task.FromResult(post);
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

    public async Task<List<BaseEntity>> GetRecentActivitiesAsync(int pageNumber, int pageSize)
    {
        var hubs = await _context.Set<Hub>()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync();
        var channels = await _context.Set<Channel>()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync();
        var hubAnnouncements = await _context.Set<HubAnnouncement>()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize / 2)
            .AsNoTracking()
            .ToListAsync();
        var channelAnnouncements = await _context.Set<ChannelAnnouncement>()
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize / 2)
            .AsNoTracking()
            .ToListAsync();
        //todo find a method to optimize the performance
        var recentActivities = new List<BaseEntity>();
        recentActivities.AddRange(hubs);
        recentActivities.AddRange(channels);
        recentActivities.AddRange((hubAnnouncements).OrderByDescending(ha => ha.CreationDate));
        recentActivities.AddRange((channelAnnouncements).OrderByDescending(ca => ca.CreationDate));
        
        recentActivities = recentActivities
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToList();
        return recentActivities;
    }

    public async Task<List<BaseEntity>> GetUserRecentActivitiesAsync(string userName, int pageNumber, int pageSize)
    {
        var user = (await _userRepository.GetAsync(
            u => u.UserName == userName,
            null!,
            "Hubs,Posts,Channels,HubAnnouncements,ChannelAnnouncements"))
                    .FirstOrDefault()!;

        var result = new List<BaseEntity>();

        result.AddRange(user.Hubs);
        result.AddRange(user.Posts);
        result.AddRange(user.Channels);
        result.AddRange(user.HubAnnouncements);
        result.AddRange(user.ChannelAnnouncements);
        result = result.OrderByDescending(r => r.CreationDate)
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToList();
        return result;


    }
}
using BusinessLogic.Domain;
using BusinessLogic.Persistence;
using BusinessLogic.Persistence.Repositories;
using BusinessLogic.IntegrationTests.Fixtures;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Tests.IntegrationTests.Options;

namespace BusinessLogic.Tests.IntegrationTests;
public class RoomRepositoryTests : IClassFixture<DbContextMySqlFixture>
{
    private readonly DbContextMySqlFixture _mysql;
    public RoomRepositoryTests(DbContextMySqlFixture mysql)
    {
        _mysql = mysql;
    }

    [Fact]
    public async Task AddAsync_AddRoomWithChannel_MustHitTheDatabase()
    {
        var roomRepository = new RoomRepository(_mysql.dbContext);
        var hub = new Hub
        {
            Id = Guid.NewGuid(),
            Name = "test",
            Description = "test"
        };
        var channel = new Channel
        {
            Id = Guid.NewGuid(),

            Name = "test",
            HubId = hub.Id,
            Description = "test",
            Hub = hub
        };
        var room = new Room
        {
            Channel = channel,
            ChannelId = channel.Id,
            Description = "test"
        };
        channel.Rooms!.Add(room);
        hub.Channels.Add(channel);
        await _mysql.dbContext.AddAsync(hub);
        // await _mysql.dbContext.AddAsync(channel);
        // await _mysql.dbContext.AddAsync(room);

        Assert.Equal(3, await _mysql.dbContext.SaveChangesAsync());
    }
    private async Task<Hub> AddHubAsync(Hub hub)
    {
        await _mysql.dbContext.Hubs!.AddAsync(hub);
        return hub;

    }
    private async Task<Channel> AddChannelAsync(Channel channel)
    {
        await _mysql.dbContext.Channels!.AddAsync(channel);
        return channel;
    }

    [Fact]//(Skip = "Doesn't work inline with other tests")]
    public async Task AddAsync_AddRoomWithoutChannel_MustThrowException()
    {
        var configuration = ConfigurationInitializer.InitializeConfiguration();
        var connectionString = configuration.GetSection("ConnectionStrings").GetSection("Default").Value;
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseMySql(connectionString,
                      ServerVersion.AutoDetect(connectionString));

        var dbContext = new ApplicationDbContext(builder.Options, configuration);
        await dbContext.Database.EnsureCreatedAsync();
        var roomRepository = new RoomRepository(dbContext);
        var room = new Room
        {
            Description = "test"
        };
        await roomRepository.AddAsync(room);
        await Assert.ThrowsAsync<DbUpdateException>(async () =>
        {
            await dbContext.SaveChangesAsync();
        });
    }
}
using BusinessLogic.Domain;
using BusinessLogic.IntegrationTests.Fixtures;
using BusinessLogic.Persistence;
using BusinessLogic.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Tests.IntegrationTests;

public class ChannelRepositoryTests : IClassFixture<DbContextMySqlFixture>
{
    private readonly DbContextMySqlFixture _mysql;
    private readonly ChannelRepository _channelRepository;
    public ChannelRepositoryTests(DbContextMySqlFixture mysql)
    {
        _mysql = mysql;
        _channelRepository = new ChannelRepository(_mysql.dbContext);
    }

    [Fact]
    public async Task AddAsync_AddChannelWithHub_MustHitTheDatabasse()
    {
        var hub = new Hub
        {
            Name = "test",
            Description = "test"
        };
        var channel = new Channel
        {
            Id = Guid.Empty,
            Name = "test",
            Description = "test",
            Hub = hub
        };

        await _mysql.dbContext.Hubs!.AddAsync(hub);
        await _channelRepository.AddAsync(channel);
        Assert.Equal(2, await _mysql.dbContext.SaveChangesAsync());
    }
    [Fact]//(Skip = "Doesn't work inline with other tests")]
    public async Task AddAsync_AddChannelWithoutHub_MustThrowException()
    {
        var configuration = ConfigurationInitializer.InitializeConfiguration();
        var connectionString = configuration.GetSection("ConnectionStrings").GetSection("Default").Value;
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        var dbContext = new ApplicationDbContext(builder.Options,configuration);
        await dbContext.Database.EnsureCreatedAsync();

        var channel = new Channel
        {
            Name = "test",
            Description = "test"
        };
        var channelRepository = new ChannelRepository(dbContext);
        await channelRepository.AddAsync(channel);
        await Assert.ThrowsAsync<DbUpdateException>(async () =>
             await dbContext.SaveChangesAsync()
        );
    }
}

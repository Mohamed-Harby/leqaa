using BusinessLogic.Domain;
using BusinessLogic.IntegrationTests.Fixtures;
using BusinessLogic.Persistence.Repositories;

namespace BusinessLogic.Tests.IntegrationTests;

public class HubRepositoryTests : IClassFixture<DbContextMySqlFixture>
{
    private readonly DbContextMySqlFixture _mysqlFixture;

    public HubRepositoryTests(DbContextMySqlFixture mysqlFixture)
    {
        _mysqlFixture = mysqlFixture;
    }

    [Fact]
    public async Task AddAsync_AddHub_MustHitTheDatabase()
    {

        // await dbContext.Database.EnsureDeletedAsync();
        await _mysqlFixture.dbContext.Database.EnsureCreatedAsync();
        var hubRepository = new HubRepository(_mysqlFixture.dbContext);
        var hub = new Hub
        {
            Name = "test",
            Description = "test"
        };
        await hubRepository.AddAsync(hub);
        Assert.Equal(1, await _mysqlFixture.dbContext.SaveChangesAsync());

    }
}

using BusinessLogic.Domain;
using BusinessLogic.Persistence.Repositories;
using BusinessLogic.UnitTest.Fixtures;

namespace BusinessLogic.Tests.UnitTests;
public class HubRepositoryTestsInMemory : IClassFixture<DbContextMemoryFixture>
{
    public DbContextMemoryFixture _memoryDb;
    public HubRepositoryTestsInMemory(DbContextMemoryFixture memory)
    {
        _memoryDb = memory;
    }

    [Fact]
    public async Task AddAsync_AddHub_MustSaveInMemory()
    {
        await _memoryDb.dbContext.Database.EnsureCreatedAsync();
        var hubRepository = new HubRepository(_memoryDb.dbContext);
        var hub = new Hub
        {
            Name = "test",
            Description = "test"
        };
        await hubRepository.AddAsync(hub);
        hub = new Hub
        {
            Name = "test2",
            Description = "test2"
        };
        await hubRepository.AddAsync(hub);

        Assert.Equal(2, await _memoryDb.dbContext.SaveChangesAsync());
    }
}
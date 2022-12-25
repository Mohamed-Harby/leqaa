using BusinessLogic.Domain;
using BusinessLogic.Persistence;
using BusinessLogic.Persistence.Repositories;
using BusinessLogic.UnitTest.Fixtures;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.UnitTest;
public class HubRepositoryTestsInMemory : IClassFixture<DbContextMemoryFixture>
{
    public DbContextMemoryFixture _memoryDb;
    public HubRepositoryTestsInMemory(DbContextMemoryFixture memory)
    {
        _memoryDb = memory;
    }

    [Fact]
    public async Task AddAsync_AddHub_MustHitTheDatabase()
    {
        await _memoryDb.dbContext.Database.EnsureCreatedAsync();
        var hubRepository = new HubRepository(_memoryDb.dbContext);
        var hub = new Hub
        {
            Name = "test",
            Description = "test"
        };
        await hubRepository.AddAsync(hub);
        Assert.Equal(1, await _memoryDb.dbContext.SaveChangesAsync());
    }
}
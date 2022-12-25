using BusinessLogic.Domain;
using BusinessLogic.Persistence;
using BusinessLogic.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.UnitTest;
public class HubRepositoryTests
{
    [Fact]
    public async Task AddAsync_AddHub_MustHitTheDatabase()
    {
        var connectionString = "server=localhost;database=leqaaBusinessTestDb;Uid=root;Pwd=2510203121";
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        using var dbContext = new ApplicationDbContext(builder.Options);
        // await dbContext.Database.EnsureDeletedAsync();
        await dbContext.Database.EnsureCreatedAsync();
        var hubRepository = new HubRepository(dbContext);
        var hub = new Hub
        {
            Name = "test",
            Description = "test"
        };
        await hubRepository.AddAsync(hub);
        Assert.Equal(1, await dbContext.SaveChangesAsync());

    }
}
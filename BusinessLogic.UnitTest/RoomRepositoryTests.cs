using BusinessLogic.Domain;
using BusinessLogic.Persistence;
using BusinessLogic.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.UnitTest;
public class RoomRepositoryTests
{
    [Fact]
    public async Task AddAsync_AddRoomWithoutChannel_MustThrowException()
    {
        var connectionString = "server=localhost;database=leqaaBusinessTestDb;Uid=root;Pwd=2510203121";
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        using var dbContext = new ApplicationDbContext(builder.Options);
        // await dbContext.Database.EnsureDeletedAsync();
        await dbContext.Database.EnsureCreatedAsync();
        var roomRepository = new RoomRepository(dbContext);
        var room = new Room
        {
            Description = "test"
        };
        await roomRepository.AddAsync(room);
        await Assert.ThrowsAsync<DbUpdateException>(() =>
        {
            return dbContext.SaveChangesAsync();
        });
    }
}
using BusinessLogic.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.UnitTest.Fixtures;
public class DbContextMemoryFixture : IDisposable
{
    public ApplicationDbContext dbContext;
    public DbContextMemoryFixture()
    {
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseInMemoryDatabase(nameof(DbContextMemoryFixture));
        dbContext = new ApplicationDbContext();
    }
    public void Dispose()
    {
        dbContext.Dispose();
    }
}

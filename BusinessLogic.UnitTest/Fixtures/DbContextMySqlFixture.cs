using BusinessLogic.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.UnitTest.Fixtures;
public class DbContextMySqlFixture
{
    public ApplicationDbContext dbContext;
    public DbContextMySqlFixture()
    {
        var connectionString = "server=localhost;database=leqaaBusinessTestDb;Uid=root;Pwd=2510203121";
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        dbContext = new ApplicationDbContext(builder.Options);
    }

}
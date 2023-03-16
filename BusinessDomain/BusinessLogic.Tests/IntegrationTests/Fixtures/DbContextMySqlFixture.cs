using BusinessLogic.Persistence;
using BusinessLogic.Tests.IntegrationTests;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.IntegrationTests.Fixtures;
public class DbContextMySqlFixture
{
    public ApplicationDbContext dbContext;
    public DbContextMySqlFixture()
    {
        var configuration = ConfigurationInitializer.InitializeConfiguration();
        var connectionString = configuration.GetSection("ConnectionStrings").GetSection("Default").Value;
        System.Console.WriteLine(connectionString);
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), options => options.EnableRetryOnFailure())
        .EnableSensitiveDataLogging();
        dbContext = new ApplicationDbContext(builder.Options,configuration);
        // dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();
    }

}
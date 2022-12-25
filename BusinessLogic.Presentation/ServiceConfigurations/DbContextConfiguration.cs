using BusinessLogic.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Presentation.ServiceConfigurations;
public static class DbContextConfiguration
{
    public static IServiceCollection AddDbContextConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default");
        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseMySql(connectionString,
                          ServerVersion.AutoDetect(connectionString))
                          .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        return services;
    }
}
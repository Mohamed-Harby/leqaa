using BusinessLogic.Application.Interfaces;
using BusinessLogic.Persistence.Repositories;

namespace BusinessLogic.Presentation.ServiceConfigurations;
public static class HubRepositoryConfiguration
{
    public static IServiceCollection AddHubRepository(this IServiceCollection services)
    {
        services.AddScoped<IHubRepository, HubRepository>();
        return services;
    }
}
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Persistence.Repositories;

namespace BusinessLogic.Presentation.ServiceConfigurations;
public static class AnnouncementRepositoryConfiguration
{
    public static IServiceCollection AddAnnouncementRepository(this IServiceCollection services)
    {
        services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
        return services;
    }
}
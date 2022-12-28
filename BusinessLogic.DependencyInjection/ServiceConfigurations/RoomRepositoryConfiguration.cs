using BusinessLogic.Application.Interfaces;
using BusinessLogic.Persistence.Repositories;

namespace BusinessLogic.Presentation.ServiceConfigurations;
public static class RoomRepositoryConfiguration
{
    public static IServiceCollection AddRoomRepository(this IServiceCollection services)
    {
        services.AddScoped<IRoomRepository, RoomRepository>();
        return services;
    }
}
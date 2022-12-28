using BusinessLogic.Application.Interfaces;
using BusinessLogic.Persistence.UnitsOfWork;

namespace BusinessLogic.Presentation.ServiceConfigurations;
public static class UnitOfWorkConfiguration
{
    public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
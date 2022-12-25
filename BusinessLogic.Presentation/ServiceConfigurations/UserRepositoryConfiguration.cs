using BusinessLogic.Persistence.Repositories;

namespace BusinessLogic.Presentation.ServiceConfigurations;
public static class UserRepositoryConfiguration
{
    public static IServiceCollection AddUserRepository(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}
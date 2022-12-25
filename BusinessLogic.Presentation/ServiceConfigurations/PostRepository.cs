using BusinessLogic.Application.Interfaces;
using BusinessLogic.Persistence.Repositories;

namespace BusinessLogic.Presentation.ServiceConfigurations;
public static class PostRepositoryConfiguration
{
    public static IServiceCollection AddPostRepository(this IServiceCollection services)
    {
        services.AddScoped<IPostRepository, PostRepository>();
        return services;
    }
}
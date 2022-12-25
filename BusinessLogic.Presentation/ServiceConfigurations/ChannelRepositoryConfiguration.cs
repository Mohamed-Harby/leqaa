using BusinessLogic.Application.Interfaces;
using BusinessLogic.Persistence.Repositories;

namespace BusinessLogic.Presentation.ServiceConfigurations
{
    public static class ChannelRepositoryConfiguration
    {
        public static IServiceCollection AddChannelRepository(this IServiceCollection services)
        {
            services.AddScoped<IChannelRepository, ChannelRepository>();
            return services;
        }
    }
}
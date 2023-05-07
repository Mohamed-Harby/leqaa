﻿using BusinessLogic.Application.Interfaces;
using BusinessLogic.Persistence.Interceptors;
using BusinessLogic.Persistence.Repositories;
using BusinessLogic.Persistence.UnitsOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Persistence.DependencyInjection;

public static class PersistenceDependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default");
        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseMySql(connectionString,
                          ServerVersion.AutoDetect(connectionString))
                          .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll).EnableSensitiveDataLogging()
                          , ServiceLifetime.Scoped);
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IHubRepository, HubRepository>();
        services.AddScoped<IChannelRepository, ChannelRepository>();
        services.AddScoped<IRoomRepository, RoomRepository>();

        services.AddScoped<IHubAnnouncementRepository, HubAnnouncementRepository>();
        services.AddScoped<IChannelAnnouncementRepository, ChannelAnnouncementRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPlanRepository, PlanRepository>();
        services.AddScoped<IUserHubRepository, UserHubRepository>();
        services.AddScoped<IUserChannelRepository, UserChannelRepository>();
        services.AddScoped<IUserUserRepository, UserUserRepository>();


        services.AddScoped<IUserPinnedChannelRepository, UserPinnedChannelRepository>();
        services.AddScoped<IUserPinnedHubRepository, UserPinnedHubRepository>();
        services.AddScoped<IUserPinnedPostRepository, UserPinnedPostRepository>();

        services.AddScoped<IPublishDomainEventsInterceptor, PublishDomainEventsInterceptor>();
        services.AddScoped<PublishDomainEventsInterceptor>();


        return services;
    }
}

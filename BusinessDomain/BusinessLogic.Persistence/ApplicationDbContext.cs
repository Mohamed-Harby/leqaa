using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using BusinessLogic.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessLogic.Persistence;
public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<User>? Users { get; set; }
    public DbSet<Hub>? Hubs { get; set; }
    public DbSet<Channel>? Channels { get; set; }
    public DbSet<Room>? Rooms { get; set; }
    public DbSet<Post>? Posts { get; set; }
    public DbSet<HubAnnouncement>? HubAnnouncements { get; set; }
    public DbSet<ChannelAnnouncement>? ChannelAnnouncements { get; set; }
    public DbSet<Plan>? Plans { get; set; }
    private readonly IConfiguration? configuration;
    private readonly PublishDomainEventsInterceptor _interceptor;

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration, PublishDomainEventsInterceptor interceptor) : base(options)
    {
        this.configuration = configuration;
        _interceptor = interceptor;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.AddInterceptors(_interceptor);

        var connectionString = configuration.GetConnectionString("Default");
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(connectionString,
                            ServerVersion.AutoDetect(connectionString))
                            .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
        }

        base.OnConfiguring(optionsBuilder);
    }
    protected async override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        await modelBuilder.SeedDataAsync();
        base.OnModelCreating(modelBuilder);

    }
}
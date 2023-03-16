using BusinessLogic.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessLogic.Persistence;
public class ApplicationDbContext : DbContext
{
    public DbSet<User>? Users { get; set; }
    public DbSet<Hub>? Hubs { get; set; }
    public DbSet<Channel>? Channels { get; set; }
    public DbSet<Room>? Rooms { get; set; }
    private readonly IConfiguration? configuration;
    public ApplicationDbContext()
    {

    }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
    {
        this.configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
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
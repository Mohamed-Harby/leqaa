using BusinessLogic.Domain;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Persistence;
public class ApplicationDbContext : DbContext
{
    public DbSet<User>? Users { get; set; }
    public DbSet<Hub>? Hubs { get; set; }
    public DbSet<Channel>? Channels { get; set; }
    public DbSet<Room>? Rooms { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql("server=localhost;database=LeqaaBusiness;Uid=root;pwd=2510203121",
                              ServerVersion.AutoDetect("server=localhost;database=LeqaaBusiness;Uid=root;pwd=2510203121"))
                              .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
        }
        base.OnConfiguring(optionsBuilder);

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
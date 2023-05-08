using BusinessLogic.Domain;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Application.Interfaces;
public interface IApplicationDbContext
{
    DbSet<User>? Users { get; set; }
    DbSet<Hub>? Hubs { get; set; }
    DbSet<Channel>? Channels { get; set; }
    DbSet<Room>? Rooms { get; set; }
    DbSet<Post>? Posts { get; set; }
    DbSet<HubAnnouncement>? HubAnnouncements { get; set; }
    DbSet<ChannelAnnouncement>? ChannelAnnouncements { get; set; }
    DbSet<Plan>? Plans { get; set; }
    

}
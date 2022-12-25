using BusinessLogic.Domain;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Persistence.Configurations;
public class UserConfiguration : BaseConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder
        .HasMany(u => u.Posts)
        .WithOne(p => p.User)
        .HasForeignKey(p => p.UserId);

        builder.HasMany(u => u.Channels).WithMany(c => c.Users);
        builder.HasMany(u => u.Hubs).WithMany(h => h.Users);
        builder.HasMany(u => u.Rooms).WithMany(r => r.JoinedUsers);

        builder
        .HasMany(u => u.Announcements)
        .WithOne(a => a.User)
        .HasForeignKey(a => a.UserId);

        builder
        .HasMany(u => u.Followers)
        .WithMany(u => u.FollowedUsers);
        
        base.Configure(builder);

    }
}
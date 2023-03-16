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
        base.Configure(builder);
        //relations
        builder
        .HasMany(u => u.Posts)
        .WithOne(p => p.User)
        .HasForeignKey(p => p.UserId)
        .OnDelete(DeleteBehavior.Cascade);

        builder
        .HasMany(u => u.Channels)
        .WithMany(c => c.JoinedUsers)

        .UsingEntity<UserChannel>();


        builder
        .HasMany(u => u.Rooms)
        .WithMany(r => r.JoinedUsers)
        .UsingEntity<UserRoom>(
            join =>
            join
            .HasOne(ur => ur.Room)
            .WithMany()
            .HasForeignKey(ur => ur.RoomId),
            join =>
            join
            .HasOne(ur => ur.User)
            .WithMany()
            .HasForeignKey(ur => ur.UserId)
            .OnDelete(DeleteBehavior.Cascade)
        );

        builder
        .HasMany(u => u.HubAnnouncements)
        .WithOne(a => a.User)
        .HasForeignKey(a => a.UserId)
        .OnDelete(DeleteBehavior.Cascade);
        builder
      .HasMany(u => u.Posts)
      .WithOne(p => p.User)
      .HasForeignKey(p => p.UserId)
      .OnDelete(DeleteBehavior.Cascade);

        builder
.HasMany(u => u.ChannelAnnouncements)
.WithOne(a => a.User)
.HasForeignKey(a => a.UserId)
.OnDelete(DeleteBehavior.Cascade);

        builder
        .HasMany(u => u.Followers)
        .WithMany(u => u.FollowedUsers).UsingEntity<UserUser>(
            join => join
            .HasOne(uu => uu.Follower)
            .WithMany()
            .HasForeignKey(uu => uu.FollowerId)
            .OnDelete(DeleteBehavior.Cascade)
            ,
            join => join
            .HasOne(uu => uu.Followed)
            .WithMany()
            .HasForeignKey(uu => uu.FollowedId)
            .OnDelete(DeleteBehavior.Cascade)
        );

        //fields that are unique
        builder
            .HasIndex(u => u.Email)
            .IsUnique();
        builder
            .HasIndex(u => u.UserName)
            .IsUnique();

        //fields that are required
        builder.Property(p => p.Name).IsRequired()
        .HasMaxLength(50);
        builder.Property(p => p.Email).IsRequired();
        builder.Property(p => p.Gender).IsRequired();
        builder.Property(p => p.UserName).IsRequired()
        .HasMaxLength(30);
        // other
        builder.Ignore(u => u.IsFollowed);



    }
}
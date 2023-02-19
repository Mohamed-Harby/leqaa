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
        //relations
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
        .WithMany(u => u.FollowedUsers).UsingEntity<UserUser>(
            join => join
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(uu => uu.FollowerId)
            ,
            join => join
            .HasOne<User>()
            .WithMany()
            .HasForeignKey(uu => uu.FollowedId)
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
        builder.Property(p => p.Password).IsRequired()
        .HasMaxLength(50);
        // builder.Property(p => p.ProfileImage).IsRequired();

        base.Configure(builder);

    }
}
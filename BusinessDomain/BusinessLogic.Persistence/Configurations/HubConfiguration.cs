using BusinessLogic.Domain;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Persistence.Configurations;
public class HubConfiguration : BaseConfiguration<Hub>
{
    public override void Configure(EntityTypeBuilder<Hub> builder)
    {
        builder.ToTable("hubs");

        base.Configure(builder);

        builder
        .HasMany(r => r.Channels)
        .WithOne(u => u.Hub)
        .OnDelete(DeleteBehavior.Cascade);

        builder
        .HasMany(h => h.Users)
        .WithMany(u => u.Hubs)
        .UsingEntity<UserHub>(
            join => join
            .HasOne(uh => uh.User)
            .WithMany()
            .HasForeignKey(uh => uh.UserId),

            join => join
            .HasOne(uh => uh.Hub)
            .WithMany()
            .HasForeignKey(uh => uh.HubId)
        );


        builder
     .HasMany(h => h.HubPinningUsers)
     .WithMany(u => u.PinnedHubs)
     .UsingEntity<UserPinnedHub>(
         join => join
         .HasOne(uh => uh.UserPinned)
         .WithMany()
         .HasForeignKey(uh => uh.UserPinnedid)
              .OnDelete(DeleteBehavior.Cascade),

         join => join
         .HasOne(uh => uh.PinnedHub)
         .WithMany()
         .HasForeignKey(uh => uh.PinnedHubId)
              .OnDelete(DeleteBehavior.Cascade)
     );



        builder.Property(t => t.Name).IsRequired()
        .HasMaxLength(100);
        builder.Property(t => t.Description).HasMaxLength(4000);


    }

}
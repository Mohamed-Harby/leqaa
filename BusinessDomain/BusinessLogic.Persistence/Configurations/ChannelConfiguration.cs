using BusinessLogic.Domain;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Persistence.Configurations;
public class ChannelConfiguration : BaseConfiguration<Channel>
{
    public override void Configure(EntityTypeBuilder<Channel> builder)
    {
        builder.ToTable("Channels");

        base.Configure(builder);

        builder
        .HasOne(r => r.Hub)
        .WithMany(u => u.Channels)
        .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(r => r.Announcements)
            .WithOne(a => a.Channel)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(t=>t.Name).IsRequired()
        .HasMaxLength(30);

        builder.Property(t=>t.Description).HasMaxLength(200);
        





    }

}
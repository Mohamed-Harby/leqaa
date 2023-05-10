using BusinessLogic.Domain;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Persistence.Configurations;
public class ChannelAnnouncementConfiguration : BaseConfiguration<ChannelAnnouncement>
{
    public override void Configure(EntityTypeBuilder<ChannelAnnouncement> builder)
    {



        builder.ToTable("channelAnnouncements");

        base.Configure(builder);

        builder
        .HasOne(r => r.Channel)
        .WithMany(u => u.ChannelAnnouncements)
        .OnDelete(DeleteBehavior.Cascade);
    }
}
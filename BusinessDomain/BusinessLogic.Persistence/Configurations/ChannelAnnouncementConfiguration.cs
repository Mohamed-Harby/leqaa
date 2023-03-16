using BusinessLogic.Domain;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Persistence.Configurations;
public class ChannelAnnouncementConfiguration : BaseConfiguration<ChannelAnnouncement>
{
    public override void Configure(EntityTypeBuilder<ChannelAnnouncement> builder)
    {
        base.Configure(builder);
        builder.ToTable("channelAnnouncements");
    }
}
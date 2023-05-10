using BusinessLogic.Domain;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Persistence.Configurations;
public class UserChannelAnnoucementConfiguration : BaseConfiguration<UserChannelAnnoucement>
{
    public override void Configure(EntityTypeBuilder<UserChannelAnnoucement> builder)
    {

        builder.HasKey(uh => new { uh.UserId, uh.ChannelAnnouncementId });
        builder.Property(uh => uh.Id).HasDefaultValue(Guid.NewGuid());
        builder.Property(h => h.CreationDate).HasDefaultValue(DateTime.UtcNow);
    }
}
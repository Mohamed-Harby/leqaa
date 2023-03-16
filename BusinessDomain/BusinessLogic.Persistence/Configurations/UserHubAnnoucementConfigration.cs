using BusinessLogic.Domain;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Persistence.Configurations;
public class UserHubAnnoucementConfigration : BaseConfiguration<UserHubAnnouncement>
{
    public override void Configure(EntityTypeBuilder<UserHubAnnouncement> builder)
    {

        builder.HasKey(uh => new { uh.UserId, uh.HubAnnouncementId });
        builder.Property(uh => uh.Id).HasDefaultValue(Guid.NewGuid());
        builder.Property(h => h.CreationDate).HasDefaultValue(DateTime.UtcNow);
    }
}
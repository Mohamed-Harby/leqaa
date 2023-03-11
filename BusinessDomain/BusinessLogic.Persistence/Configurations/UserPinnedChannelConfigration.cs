using BusinessLogic.Domain;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Persistence.Configurations;
public class UserPinnedChannelConfigration : BaseConfiguration<UserPinnedChannel>
{
    public override void Configure(EntityTypeBuilder<UserPinnedChannel> builder)
    {

        builder.HasKey(uh => new { uh.UserId, uh.PinnedChannelId });
        builder.Property(uh => uh.Id).HasDefaultValue(Guid.NewGuid());
        builder.Property(h => h.CreationDate).HasDefaultValue(DateTime.Now);
    }
}
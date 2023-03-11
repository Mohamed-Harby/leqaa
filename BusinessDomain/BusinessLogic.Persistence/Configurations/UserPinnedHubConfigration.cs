using BusinessLogic.Domain;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Persistence.Configurations;
public class UserPinnedHubConfigration : BaseConfiguration<UserPinnedHub>
{
    public override void Configure(EntityTypeBuilder<UserPinnedHub> builder)
    {

        builder.HasKey(uh => new { uh.UserId, uh.PinnedHubId });
        builder.Property(uh => uh.Id).HasDefaultValue(Guid.NewGuid());
        builder.Property(h => h.CreationDate).HasDefaultValue(DateTime.Now);
    }
}
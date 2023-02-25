using BusinessLogic.Domain;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Persistence.Configurations;
public class UserHubConfiguration : BaseConfiguration<UserHub>
{
    public override void Configure(EntityTypeBuilder<UserHub> builder)
    {

        builder.HasKey(uh => new { uh.UserId, uh.HubId });
        builder.Property(uh => uh.Id).HasDefaultValue(Guid.NewGuid()).ValueGeneratedOnAdd();
        builder.Property(h => h.CreationDate).HasDefaultValue(DateTime.Now);
    }
}
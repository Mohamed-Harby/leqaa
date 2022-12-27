using BusinessLogic.Domain;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Persistence.Configurations;
public class UserHubConfiguration : BaseConfiguration<UserHub>
{
    public override void Configure(EntityTypeBuilder<UserHub> builder)
    {
        // base.Configure(builder);
        builder.HasKey(uh => new { uh.UserId, uh.HubId });


    }
}
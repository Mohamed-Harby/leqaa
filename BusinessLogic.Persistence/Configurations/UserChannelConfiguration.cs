using BusinessLogic.Domain;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Persistence.Configurations;
public class UserChannelConfiguration : BaseConfiguration<UserChannel>
{
    public override void Configure(EntityTypeBuilder<UserChannel> builder)
    {
        // base.Configure(builder);
        builder.HasKey(uc=> new { uc.UserId, uc.ChannelId});


    }
}
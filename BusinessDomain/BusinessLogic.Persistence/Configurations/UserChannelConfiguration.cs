using BusinessLogic.Domain;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Persistence.Configurations;
public class UserChannelConfiguration : BaseConfiguration<UserChannel>
{
    public override void Configure(EntityTypeBuilder<UserChannel> builder)
    {
        builder.HasKey(uc => new { uc.UserId, uc.ChannelId });
        builder.Property(uc => uc.CreationDate).HasDefaultValue(DateTime.UtcNow);


    }
}
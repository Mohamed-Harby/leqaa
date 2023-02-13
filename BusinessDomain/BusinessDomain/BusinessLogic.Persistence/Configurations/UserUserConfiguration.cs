using BusinessLogic.Domain;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Persistence.Configurations;
public class UserUserConfiguration : BaseConfiguration<UserUser>
{
    public override void Configure(EntityTypeBuilder<UserUser> builder)
    {
        // base.Configure(builder);
        builder.HasKey(uu => new { uu.FollowerId, uu.FollowedId });
        builder.Property(uu => uu.CreationDate).HasDefaultValue(DateTime.Now);
    }
}
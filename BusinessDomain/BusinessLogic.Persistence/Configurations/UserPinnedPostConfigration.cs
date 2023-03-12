using BusinessLogic.Domain;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Persistence.Configurations;
public class UserPinnedPostConfigration : BaseConfiguration<UserPinnedPost>
{
    public override void Configure(EntityTypeBuilder<UserPinnedPost> builder)
    {

        builder.HasKey(uh => new { uh.UserPinnedId, uh.PinnedPostId});
        builder.Property(uh => uh.Id).HasDefaultValue(Guid.NewGuid());
        builder.Property(h => h.CreationDate).HasDefaultValue(DateTime.Now);
    }
}
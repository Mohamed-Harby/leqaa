using BusinessLogic.Domain;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Persistence.Configurations;
public class PinnedPostConfiguration : BaseConfiguration<PinnedPost>
{
    public override void Configure(EntityTypeBuilder<PinnedPost> builder)
    {
        builder.ToTable("PinnedPost");

    }

}
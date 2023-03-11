using BusinessLogic.Domain;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Persistence.Configurations;
public class PinnedHubConfiguration : BaseConfiguration<PinnedHub>
{
    public override void Configure(EntityTypeBuilder<PinnedHub> builder)
    {
        builder.ToTable("pinnedHups");

        base.Configure(builder);


    }

}
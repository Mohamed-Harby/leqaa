using BusinessLogic.Domain;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Persistence.Configurations;
public class PinnedChannelConfiguration : BaseConfiguration<PinnedChannel>
{
    public override void Configure(EntityTypeBuilder<PinnedChannel> builder)
    {
        builder.ToTable("pinnedChannel");

        base.Configure(builder);

  
      

     

    }

}
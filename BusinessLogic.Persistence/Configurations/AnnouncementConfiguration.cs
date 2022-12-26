using BusinessLogic.Domain;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Persistence.Configurations;
public class AnnouncementConfiguration : BaseConfiguration<Announcement>
{
    public override void Configure(EntityTypeBuilder<Announcement> builder)
    {
        builder.ToTable("announcements");

        base.Configure(builder);



    }

}
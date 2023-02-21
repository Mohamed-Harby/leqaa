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



        builder.Property(t=>t.Title).IsRequired()
        .HasMaxLength(50);
        builder.Property(t=>t.content).IsRequired()
        .HasMaxLength(500);
        

    }

}
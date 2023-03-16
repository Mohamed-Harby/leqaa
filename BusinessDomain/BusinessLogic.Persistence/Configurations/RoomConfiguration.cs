using BusinessLogic.Domain;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Persistence.Configurations;
public class RoomConfiguration : BaseConfiguration<Room>
{
    public override void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable("rooms");

        base.Configure(builder);

        builder
        .HasOne(r => r.Channel)
        .WithMany(u => u.Rooms)
        .OnDelete(DeleteBehavior.Cascade);


        builder.Property(p => p.Description).IsRequired()
        .HasMaxLength(100);
        builder.Property(p => p.StartedAt).HasDefaultValue(DateTime.UtcNow);
    }

}
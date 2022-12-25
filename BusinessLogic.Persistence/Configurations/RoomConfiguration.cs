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
        .HasMany(r=>r.JoinedUsers)
        .WithMany(u=>u.Rooms);

    }

}
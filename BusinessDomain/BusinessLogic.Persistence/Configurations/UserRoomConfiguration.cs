using BusinessLogic.Domain;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Persistence.Configurations;
public class UserRoomConfiguration : BaseConfiguration<UserRoom>
{
    public override void Configure(EntityTypeBuilder<UserRoom> builder)
    {
        builder.HasKey(ur => new { ur.UserId, ur.RoomId });
        builder.Property(ur => ur.CreationDate).HasDefaultValue(DateTime.Now);
    }
}
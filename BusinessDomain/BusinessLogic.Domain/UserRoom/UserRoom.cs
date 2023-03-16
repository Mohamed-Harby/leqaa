using BusinessLogic.Domain.SharedEnums;

namespace BusinessLogic.Domain;
public class UserRoom : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid RoomId { get; set; }
    public User User { get; set; } = null!;
    public Room Room { get; set; } = null!;
    public GroupRole Role { get; set; } = GroupRole.Member;

}
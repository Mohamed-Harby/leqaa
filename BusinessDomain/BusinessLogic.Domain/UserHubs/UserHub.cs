using BusinessLogic.Domain.SharedEnums;

namespace BusinessLogic.Domain;
public class UserHub : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid HubId { get; set; }
    public User User { get; set; } = null!;
    public Hub Hub { get; set; } = null!;
    public GroupRole Role { get; set; } = GroupRole.Member;
}
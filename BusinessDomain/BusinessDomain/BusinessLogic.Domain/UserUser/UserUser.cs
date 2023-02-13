namespace BusinessLogic.Domain;
public class UserUser : BaseEntity
{
    public Guid FollowerId { get; set; }
    public Guid FollowedId { get; set; }
    public User Follower { get; set; } = null!;
    public User Followed { get; set; } = null!;
}
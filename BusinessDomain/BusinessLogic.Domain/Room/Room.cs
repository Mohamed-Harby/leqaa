namespace BusinessLogic.Domain;
public class Room : BaseEntity
{
    public Room()
    {
        JoinedUsers = new HashSet<User>();
    }
    public int NumberOfJoinedUsers { get; set; }
    public string? Description { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime EndedAt { get; set; }
    public Guid ChannelId { get; set; }
    public Channel Channel { get; set; } = null!;
    public virtual ICollection<User> JoinedUsers { get; set; }

}
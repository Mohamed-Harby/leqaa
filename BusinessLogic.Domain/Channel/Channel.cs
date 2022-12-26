namespace BusinessLogic.Domain;
public class Channel : BaseEntity
{
    public Channel()
    {
        Rooms = new List<Room>();
        Users = new List<User>();
        Announcements = new List<Announcement>();

    }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid HubId { get; set; }
    public Hub Hub { get; set; } = null!;

    public virtual ICollection<Announcement>? Announcements { get; set; }
    public virtual ICollection<Room>? Rooms { get; set; }
    public virtual ICollection<User> Users { get; set; }
}
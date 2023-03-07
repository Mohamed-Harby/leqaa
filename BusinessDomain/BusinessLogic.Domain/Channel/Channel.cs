using System.Threading.Channels;

namespace BusinessLogic.Domain;
public class Channel : BaseEntity
{
    public Channel()
    {
        Rooms = new HashSet<Room>();
        Users = new HashSet<User>();
        Announcements = new HashSet<Announcement>();

    }

    public Channel(string name, Guid hubId, string description = "")
    {
        Name = name;
        Description = description;
        HubId = hubId;
        Rooms = new HashSet<Room>();
        Users = new HashSet<User>();
        Announcements = new HashSet<Announcement>();


    }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid HubId { get; set; }
    public bool IsPrivate { get; set; }
    public Hub Hub { get; set; } = null!;

    public virtual ICollection<Announcement>? Announcements { get; private set; }
    public virtual ICollection<Room>? Rooms { get; private set; }
    public virtual ICollection<User> Users { get; private set; }
    public void AddUser(User user)
    {
        Users.Add(user);
    }
}
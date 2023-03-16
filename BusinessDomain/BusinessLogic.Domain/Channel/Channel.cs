using System.Threading.Channels;

namespace BusinessLogic.Domain;
public class Channel : BaseEntity
{
    public Channel()
    {
        Rooms = new HashSet<Room>();
        JoinedUsers = new HashSet<User>();
        ChannelAnnouncements = new HashSet<ChannelAnnouncement>();
        PinningUsers = new HashSet<User>();
    }

    public Channel(string name, Guid hubId, string description = "")
    {
        Name = name;
        Description = description;
        HubId = hubId;
        Rooms = new HashSet<Room>();
        JoinedUsers = new HashSet<User>();
        ChannelAnnouncements = new HashSet<ChannelAnnouncement>();
        PinningUsers = new HashSet<User>();
    }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid HubId { get; set; }
    public bool IsPrivate { get; set; }
    public byte[]? Image { get; set; }
    public Hub Hub { get; set; } = null!;

    public virtual ICollection<ChannelAnnouncement> ChannelAnnouncements { get; private set; }
    public virtual ICollection<Room> Rooms { get; private set; }
    public virtual ICollection<User> JoinedUsers { get; private set; }

    public ICollection<User> PinningUsers { get; set; }

    public void AddUser(User user)
    {
        JoinedUsers.Add(user);
    }


}
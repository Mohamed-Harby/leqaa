using System.Threading.Channels;

namespace BusinessLogic.Domain;
public class Channel : BaseEntity
{
    public Channel()
    {
        Rooms = new HashSet<Room>();
        Users = new HashSet<User>();
        ChannelAnnouncements = new HashSet<ChannelAnnouncement>();
        PinnedChannels = new HashSet<PinnedChannel>();


    }

    public Channel(string name, Guid hubId, string description = "")
    {
        Name = name;
        Description = description;
        HubId = hubId;
        Rooms = new HashSet<Room>();
        Users = new HashSet<User>();
        ChannelAnnouncements = new HashSet<ChannelAnnouncement>();
        PinnedChannels = new HashSet<PinnedChannel>();


    }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Guid HubId { get; set; }
    public bool IsPrivate { get; set; }
    public byte[]? Image { get; set; }
    public Hub Hub { get; set; } = null!;

    public virtual ICollection<ChannelAnnouncement> ChannelAnnouncements { get; private set; }
    public virtual ICollection<Room> Rooms { get; private set; }
    public virtual ICollection<User> Users { get; private set; }

    public ICollection<PinnedChannel> PinnedChannels { get; set; }

    public void AddUser(User user)
    {
        Users.Add(user);
    }


}
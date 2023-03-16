namespace BusinessLogic.Domain;
public class Hub : BaseEntity
{
    public Hub()
    {
        JoinedUsers = new HashSet<User>();
        Channels = new HashSet<Channel>();
        HubAnnouncements = new HashSet<HubAnnouncement>();
        PinningUsers = new HashSet<User>();

    }
    public Hub(string name, byte[] logo = null!, string description = "")
    {
        Name = name;
        Description = description;
        Logo = logo;
        JoinedUsers = new HashSet<User>();
        Channels = new HashSet<Channel>();
        HubAnnouncements = new HashSet<HubAnnouncement>();
        PinningUsers = new HashSet<User>();
    }

    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public byte[]? Logo { get; set; }
    public bool IsPrivate { get; set; }
    public virtual ICollection<User> JoinedUsers { get; private set; }
    public virtual ICollection<Channel> Channels { get; private set; }
    public virtual ICollection<HubAnnouncement> HubAnnouncements { get; private set; }
    public ICollection<User> PinningUsers { get; set; }

    public void AddUser(User user)
    {
        JoinedUsers.Add(user);
    }
    public void AddChannel(Channel channel)
    {
        Channels.Add(channel);
    }
    public void AddHubAnnoucement(HubAnnouncement hubAnnouncement)
    {
        HubAnnouncements.Add(hubAnnouncement);
    }
}
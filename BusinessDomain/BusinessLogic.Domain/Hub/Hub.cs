namespace BusinessLogic.Domain;
public class Hub : BaseEntity
{
    public Hub()
    {
        Users = new HashSet<User>();
        Channels = new HashSet<Channel>();
        HubAnnouncements = new HashSet<HubAnnouncement>();
        HubPinningUsers = new HashSet<User>();

    }
    public Hub(string name, string logo = null!, string description = "")
    {
        Name = name;
        Description = description;
        Logo = logo is null ? null! : Convert.FromBase64String(logo);
        Users = new HashSet<User>();
        Channels = new HashSet<Channel>();
        HubAnnouncements = new HashSet<HubAnnouncement>();
        HubPinningUsers = new HashSet<User>();
    }

    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public byte[]? Logo { get; set; }
    public bool IsPrivate { get; set; }
    public virtual ICollection<User> Users { get; private set; }
    public virtual ICollection<Channel> Channels { get; private set; }
    public virtual ICollection<HubAnnouncement> HubAnnouncements { get; private set; }
    public ICollection<User> HubPinningUsers { get; set; }

    public void AddUser(User user)
    {
        Users.Add(user);
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
namespace BusinessLogic.Domain;
public class Hub : BaseEntity
{
    public Hub()
    {
        Users = new HashSet<User>();
        Channels = new HashSet<Channel>();
    }
    public Hub(string name, string logo = null!, string description = "")
    {
        Name = name;
        Description = description;
        Logo = logo is null ? null! : Convert.FromBase64String(logo);
        Users = new HashSet<User>();
        Channels = new HashSet<Channel>();
    }

    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public byte[]? Logo { get; set; }
    public virtual ICollection<User> Users { get; private set; }
    public virtual ICollection<Channel> Channels { get; private set; }


    public void AddUser(User user)
    {
        Users.Add(user);
    }
    public void AddChannel(Channel channel)
    {
        Channels.Add(channel);
    }

}
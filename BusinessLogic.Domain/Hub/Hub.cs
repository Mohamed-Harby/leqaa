namespace BusinessLogic.Domain;
public class Hub : BaseEntity
{
    public Hub()
    {
        Users = new List<User>();
        Channels = new List<Channel>();
    }

    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public byte[]? Logo { get; set; }
    public virtual ICollection<User> Users { get; set; }
    public virtual ICollection<Channel> Channels { get; set; }
}
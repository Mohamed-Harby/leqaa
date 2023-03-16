namespace BusinessLogic.Domain;
public class ChannelAnnouncement : BaseEntity
{

    public ChannelAnnouncement()
    {


    }
    public ChannelAnnouncement(string title, string content, byte[]? image)
    {

        Title = title;
        Content = content;
        Image = image;

    }
    public string Title { get; set; } = string.Empty;
    public string? Content { get; set; }
    public byte[]? Image { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public Guid ChannelId { get; set; }
    public Channel Channel { get; set; } = null!;
}
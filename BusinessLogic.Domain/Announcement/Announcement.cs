namespace BusinessLogic.Domain;
public class Announcement : BaseEntity
{
    public string RoleName { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string? content { get; set; }
    public byte[]? Image { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public Guid ChannelId { get; set; }
    public Channel Channel { get; set; } = null!;
}
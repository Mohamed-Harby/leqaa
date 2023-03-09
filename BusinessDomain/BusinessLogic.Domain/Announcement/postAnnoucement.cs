namespace BusinessLogic.Domain;
public class PostAnnoucement : BaseEntity
{

    public string Title { get; set; } = string.Empty;
    public string? Content { get; set; }
    public byte[]? Image { get; set; }

    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid PostId { get; set; }
    public Post post { get; set; } = null!;
}
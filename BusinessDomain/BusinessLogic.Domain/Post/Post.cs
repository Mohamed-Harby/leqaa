namespace BusinessLogic.Domain;
public class Post: BaseEntity
{





    public string Title { get; set; } = string.Empty;
    public string? Content { get; set; }
    public byte[]? Image { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;






}
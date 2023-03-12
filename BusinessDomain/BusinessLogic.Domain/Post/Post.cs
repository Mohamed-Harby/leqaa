namespace BusinessLogic.Domain;
public class Post : BaseEntity
{  public Post()
    {

        PostPinningUsers=new HashSet<User>();
    }
    public string Title { get; set; } = string.Empty;
    public string? Content { get; set; }
    public byte[]? Image { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public ICollection<User> PostPinningUsers { get; set; }
    public void SetUser(User user)
    {
        User = user;
    }






}
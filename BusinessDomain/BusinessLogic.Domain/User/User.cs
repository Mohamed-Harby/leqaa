namespace BusinessLogic.Domain;

public enum Gender
{
    male,
    female
};
public class User : BaseEntity
{
    public User()
    {
        Rooms = new HashSet<Room>();
        FollowedUsers = new HashSet<User>();
        Followers = new HashSet<User>();
    }
    public User(string name, string email, string password, string username, Gender gender)
    {
        Name = name;
        Email = email;
        Password = password;
        Username = username;
        Gender = gender;
    }

    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public Gender Gender { get; set; }
    public byte[]? ProfileImage { get; set; }
    public virtual ICollection<Room>? Rooms { get; set; }
    public virtual ICollection<Channel>? Channels { get; set; }
    public virtual ICollection<Hub>? Hubs { get; set; }
    public virtual ICollection<Post>? Posts { get; set; }
    public virtual ICollection<Announcement>? Announcements { get; set; }
    public virtual ICollection<User>? Followers { get; set; }
    public virtual ICollection<User>? FollowedUsers { get; set; }


}
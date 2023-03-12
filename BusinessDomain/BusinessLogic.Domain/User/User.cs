using BusinessLogic.Domain.Plan;
using BusinessLogic.Domain.Enums;
namespace BusinessLogic.Domain;
public class User : BaseEntity
{
    public User()
    {
        Rooms = new HashSet<Room>();
        FollowedUsers = new HashSet<User>();
        Followers = new HashSet<User>();
        Hubs = new HashSet<Hub>();
        Channels = new HashSet<Channel>();
        Posts = new HashSet<Post>();
        HubAnnouncements = new HashSet<HubAnnouncement>();
        ChannelAnnouncements = new HashSet<ChannelAnnouncement>();
        PinnedChannels = new HashSet<Channel>();
        PinnedPosts = new HashSet<Post>();
        PinnedHubs = new HashSet<Hub>();


        Plans = new List<Plan.Plan>();
    }
    public User(string name, string email, string username, Gender gender)
    {
        Rooms = new HashSet<Room>();
        FollowedUsers = new HashSet<User>();
        Followers = new HashSet<User>();
        Hubs = new HashSet<Hub>();
        Channels = new HashSet<Channel>();
        Posts = new HashSet<Post>();
        HubAnnouncements = new HashSet<HubAnnouncement>();
        ChannelAnnouncements = new HashSet<ChannelAnnouncement>();
        PinnedChannels=new HashSet<Channel>();
        PinnedPosts=new HashSet<Post>();
        PinnedHubs=new HashSet<Hub>();



        /* UserChannelAnnoucement = new HashSet<UserChannelAnnoucement>();*/

        Plans = new List<Plan.Plan>();

        Name = name;
        Email = email;
        UserName = username;
        Gender = gender;
    }

    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public bool IsFollowed { get; set; }
    public Gender Gender { get; set; }
    public byte[]? ProfilePicture { get; set; }
    public virtual ICollection<Room> Rooms { get; set; }
    public virtual ICollection<Channel> Channels { get; set; }
    public virtual ICollection<Hub> Hubs { get; set; }
    public virtual ICollection<Post> Posts { get; set; }
    public virtual ICollection<HubAnnouncement> HubAnnouncements { get; set; }
    public virtual ICollection<ChannelAnnouncement> ChannelAnnouncements { get; set; }
    public virtual ICollection<Channel> PinnedChannels { get; set; }
    public virtual ICollection<Post> PinnedPosts { get; set; }
    public virtual ICollection<Hub> PinnedHubs { get; set; }
    public virtual ICollection<Plan.Plan> Plans { get; set; }
    public virtual ICollection<User> Followers { get; set; }
    public virtual ICollection<User> FollowedUsers { get; set; }
}
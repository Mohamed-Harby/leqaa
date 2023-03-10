using System.Threading.Channels;
using System.Xml.Linq;
using static BusinessLogic.Domain.DomainErrors.DomainErrors;
using static BusinessLogic.Domain.DomainSucceeded.User.DomainSucceded;

namespace BusinessLogic.Domain;
public class HubAnnouncement : BaseEntity
{
    public HubAnnouncement()
    {


    }
    public HubAnnouncement(string title, string content, byte[]? image)
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
    public Guid HubId { get; set; }
    public Hub Hub { get; set; } = null!;




}
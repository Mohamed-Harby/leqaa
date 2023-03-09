using static BusinessLogic.Domain.DomainErrors.DomainErrors;

namespace BusinessLogic.Domain;
public class HubAnnouncement : BaseEntity
{

    public string Title { get; set; } = string.Empty;
    public string? Content { get; set; }
    public byte[]? Image { get; set; }

    public Guid UserAnnounceId { get; set; }
    public User User { get; set; } = null!;

    public Guid HubId { get; set; }
    public HubAnnouncement Hub { get; set; } = null!;
}
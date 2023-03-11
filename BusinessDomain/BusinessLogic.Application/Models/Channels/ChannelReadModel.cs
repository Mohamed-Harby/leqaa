
using BusinessLogic.Application.Models.Annoucements.ChannelAnnoucements;
using BusinessLogic.Domain;

namespace BusinessLogic.Application.Models.Channels;
public record ChannelReadModel(
    Guid Id,
    string ChannelName,
    bool IsPrivate,
    string ChannelDescription,
    byte[]? ChannelImage,
    HashSet<ChannelAnnouncementReadModel> ChannelAnnouncements,
    DateTime CreationDate) : BaseReadModel(Id, CreationDate);

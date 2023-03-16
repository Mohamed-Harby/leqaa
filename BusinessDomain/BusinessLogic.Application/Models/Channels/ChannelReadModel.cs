
using BusinessLogic.Application.Models.Annoucements.ChannelAnnoucements;
using BusinessLogic.Application.Models.Users;
using BusinessLogic.Domain;

namespace BusinessLogic.Application.Models.Channels;
public record ChannelReadModel(
    Guid Id,
    string Name,
    bool IsPrivate,
    string Description,
    byte[]? Image,
    List<ChannelAnnouncementReadModel> ChannelAnnouncements,
    List<UserReadModel> JoinedUsers,
    DateTime CreationDate) : BaseReadModel(Id, CreationDate);

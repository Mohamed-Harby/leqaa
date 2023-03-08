
namespace BusinessLogic.Application.Models.Channels;
public record ChannelReadModel(
    Guid Id,
    string HubId,
    string Name,
    bool IsPrivate,
    string Description,
    byte[]? Logo,
    DateTime CreationDate) : BaseReadModel(Id, CreationDate);

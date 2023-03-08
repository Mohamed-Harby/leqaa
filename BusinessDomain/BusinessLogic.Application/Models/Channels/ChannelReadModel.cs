
namespace BusinessLogic.Application.Models.Channels;
public record ChannelReadModel(
    Guid Id,
    string ChannelName,
    bool IsPrivate,
    string ChannelDescription,
    byte[]? ChannelImage,
    DateTime CreationDate) : BaseReadModel(Id, CreationDate);

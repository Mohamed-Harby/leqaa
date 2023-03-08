namespace BusinessLogic.Application.Models.Channels;
public record ChannelWriteModel(
    string Name,
    string Description,
    byte[]? Image,
    Guid? HubId
);
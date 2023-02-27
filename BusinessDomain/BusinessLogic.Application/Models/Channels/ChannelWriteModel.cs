namespace BusinessLogic.Application.Models.Channels;
public record ChannelWriteModel(
    string Name,
    string Description,
    Guid? HubId
);
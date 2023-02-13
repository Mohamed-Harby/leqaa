namespace BusinessLogic.Application.Models.Channels;
public record ChannelWriteModel(
    string name,
    string description,
    string hubId,
    Guid ChannelId
);
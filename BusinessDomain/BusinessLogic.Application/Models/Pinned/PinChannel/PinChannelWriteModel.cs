namespace BusinessLogic.Application.Models.Pinned.PinChannel;

public record PinChannelWriteModel(
   Guid UserId,
   Guid ChannelId
);
namespace BusinessLogic.Application.Models.Pinned.PinChannel;

public record PinChannelReadModel(
    Guid Id,
   Guid UserId,
   Guid ChannelId,
    DateTime CreationDate) : BaseReadModel(Id, CreationDate);


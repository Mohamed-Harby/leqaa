namespace BusinessLogic.Application.Models.Pinned.PinHubs;

public record PinPostReadModel(
    Guid Id,
   Guid UserId,
   Guid PostId,
    DateTime CreationDate) : BaseReadModel(Id, CreationDate);


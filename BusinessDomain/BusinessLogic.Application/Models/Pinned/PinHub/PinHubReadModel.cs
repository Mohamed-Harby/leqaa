namespace BusinessLogic.Application.Models.Pinned.PinHubs;

public record PinHubReadModel(
    Guid Id,
  string UserName,
   Guid HubId,
    DateTime CreationDate) : BaseReadModel(Id, CreationDate);


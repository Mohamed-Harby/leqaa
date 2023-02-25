namespace BusinessLogic.Application.Models.Hubs;
public record HubReadModel(
    Guid Id,
    string name,
    string description,
    byte[]? logo
);
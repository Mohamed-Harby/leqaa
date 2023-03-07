namespace BusinessLogic.Application.Models.Hubs;
public record HubWriteModel(
    string Name,
    string Description,
    bool IsPrivate,
    byte[]? Logo
);


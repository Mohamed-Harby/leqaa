namespace BusinessLogic.Application.Models.Hubs;
public record HubWriteModel(
    string name,
    string description,
    byte[]? logo
);
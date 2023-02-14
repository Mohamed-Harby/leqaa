namespace BusinessLogic.Application.Models.Rooms;
public record RoomReadModel(
    Guid Id,
    string name,
    string description,
    string? logo
);
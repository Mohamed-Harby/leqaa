namespace BusinessLogic.Application.Models.Rooms;
public record RoomWriteModel(
    string name,
    string description,
    Guid RoomId
);
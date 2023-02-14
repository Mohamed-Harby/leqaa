namespace BusinessLogic.Application.Models.Rooms;
public record RoomWriteModel(
    string name,
    string description,
    byte[]? logo,
    Guid hubId,
    Guid channelId
);
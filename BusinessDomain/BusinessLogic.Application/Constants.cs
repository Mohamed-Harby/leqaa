namespace BusinessLogic.Application;
public static class Constants
{
    public static Guid DefaultId = Guid.Parse("d33b1e60-0a85-45bf-afda-7e6e21ca7da6");
    public const string BusinessGroupExchange = "BusinessDomain.GroupExchange";
    public const string BusinessRoomExchange = "BusinessDomain.RoomExchange";
    public const string GroupCreatedQueue = "BusinessDomain.GroupCreated";
    public const string RoomCreatedQueue = "BusinessDomain.RoomCreated";
}
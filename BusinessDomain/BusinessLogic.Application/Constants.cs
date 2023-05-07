namespace BusinessLogic.Application;
public static class Constants
{
    public static Guid DefaultId = Guid.Parse("d33b1e60-0a85-45bf-afda-7e6e21ca7da6");
    public const string BusinessChannelExchange = "BusinessDomain.ChannelExchange";
    public const string BusinessRoomExchange = "BusinessDomain.RoomExchange";
    public const string ChannelCreatedQueue = "BusinessDomain.ChannelCreated";
    public const string RoomCreatedQueue = "BusinessDomain.RoomCreated";
}
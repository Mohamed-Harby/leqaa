using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Rooms;

namespace BusinessLogic.Application.Queries.Rooms.ViewRooms;
public record ViewRoomsQuery(
 int Limit ,
 string Cursor 
    
    ) : IQuery<List<RoomReadModel>>;
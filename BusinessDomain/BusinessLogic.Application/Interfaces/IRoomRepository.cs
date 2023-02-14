using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Application.Interfaces;
public interface IRoomRepository : IBaseRepo<Room>
{
    Task<Room> AddRoomWithUserAsync(Room Room, User user);
    Task<Room> UpdateRoomWithUserAsync(Room Room, User user);
    Task<Room> DeleteRoomWithUserAsync(Room Room, User user);
    Task<Room> AddRoomWithUser(Room room, User user);
}
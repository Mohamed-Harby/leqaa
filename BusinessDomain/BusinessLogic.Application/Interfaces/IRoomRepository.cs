using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Application.Interfaces;
public interface IRoomRepository : IBaseRepo<Room>
{
    Task<Room> AddRoomWithUser(Room room, User user);
}
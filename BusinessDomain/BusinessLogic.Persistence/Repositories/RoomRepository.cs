using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Persistence.Repositories;
public class RoomRepository : BaseRepo<Room>, IRoomRepository
{
    public RoomRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async  Task<Room> AddRoomWithUser(Room room, User user)
    {
        room.AddUser(user);
        await db.Set<Room>().AddAsync(room);
        return room;
    }
}
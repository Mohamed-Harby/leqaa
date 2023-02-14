using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Persistence.Repositories;
public class RoomRepository : BaseRepo<Room>, IRoomRepository
{

    private readonly ApplicationDbContext _context;
    public RoomRepository(ApplicationDbContext context) : base(context)
    {

        _context = context;
    }

    public Task<Room> AddRoomWithUserAsync(Room Room, User user)
    {
        throw new NotImplementedException();
    }

    public Task<Room> DeleteRoomWithUserAsync(Room Room, User user)
    {
        throw new NotImplementedException();
    }

    public Task<Room> UpdateRoomWithUserAsync(Room Room, User user)
    {
        throw new NotImplementedException();
    }

    public async  Task<Room> AddRoomWithUser(Room room, User user)
    {
        room.AddUser(user);
        await db.Set<Room>().AddAsync(room);
        return room;
    }
}
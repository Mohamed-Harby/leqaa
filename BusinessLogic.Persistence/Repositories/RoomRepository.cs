using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Persistence.Repositories;
public class RoomRepository : BaseRepo<Room>, IRoomRepository
{
    public RoomRepository(ApplicationDbContext context) : base(context)
    {
    }
}
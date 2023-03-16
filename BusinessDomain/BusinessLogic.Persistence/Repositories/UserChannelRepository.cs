using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Persistence.Repositories;
public class UserChannelRepository : BaseRepo<UserChannel>, IUserChannelRepository
{
    public UserChannelRepository(ApplicationDbContext db) : base(db)
    {
    }
}

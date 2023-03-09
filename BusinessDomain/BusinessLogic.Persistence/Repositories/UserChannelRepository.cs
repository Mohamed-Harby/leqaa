using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Persistence.Repositories;
public class UserChannelRepository : BaseRepo<UserHubAnnouncement>, IUserChannelRepository
{
    public UserChannelRepository(ApplicationDbContext db) : base(db)
    {
    }
}

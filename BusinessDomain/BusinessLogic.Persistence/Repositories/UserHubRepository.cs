using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Persistence.Repositories;
public class UserHubRepository : BaseRepo<UserHub>, IUserHubRepository
{
    public UserHubRepository(ApplicationDbContext db) : base(db)
    {
    }

    public void ChangeStateToAdded(UserHub userHub)
    {
        db.Entry<UserHub>(userHub).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
    }
}
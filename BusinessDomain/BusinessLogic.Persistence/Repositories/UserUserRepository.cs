using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Persistence.Repositories;
public class UserUserRepository : BaseRepo<UserUser>, IUserUserRepository
{
    public UserUserRepository(ApplicationDbContext db) : base(db)
    {
    }
}
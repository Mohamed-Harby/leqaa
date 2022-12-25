using BusinessLogic.Domain;
using CommonGenericClasses;

namespace BusinessLogic.Persistence.Repositories;
public class UserRepository : BaseRepo<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context)
    {
    }
}
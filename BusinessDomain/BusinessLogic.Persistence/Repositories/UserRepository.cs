using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using CommonGenericClasses;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Persistence.Repositories;
public class UserRepository : BaseRepo<User>, IUserRepository
{
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context) : base(context)
    {

        _context = context;
    }

    public async Task<User> GetUserWithRooms(string username)
    {
        User user = (await _context.Set<User>().Where(u => u.UserName == username).FirstOrDefaultAsync())!;
        return user;

    }
}
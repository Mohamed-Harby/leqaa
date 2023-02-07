using Microsoft.AspNetCore.Identity;

namespace Authentication.Application.Interfaces;
public interface IUserRepository<TUser> : IBaseRepo<TUser> where TUser : IdentityUser
{
    
}
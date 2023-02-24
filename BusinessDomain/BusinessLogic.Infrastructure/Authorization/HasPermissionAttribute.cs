using System.Security.Claims;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BusinessLogic.Infrastructure.Authorization;
public class HasPermissionAttribute : TypeFilterAttribute
{
    public HasPermissionAttribute() : base(typeof(HasPermissionFilter))
    {

    }
}

public class HasPermissionFilter : IAuthorizationFilter
{
    private IUserRepository _userRepository;
    

    public HasPermissionFilter(IUserRepository userRepository, Func<int, int> func)
    {
        _userRepository = userRepository;
        
    }

    public async void OnAuthorization(AuthorizationFilterContext context)
    {
        var query = context.HttpContext.Request.Query;
        string username = context.HttpContext.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        User user = await _userRepository.GetUserWithRooms(username);
        var rooms = user.Rooms ?? new HashSet<Room>();
        if (rooms.Select(r => r.Id).ToList().Contains(Guid.Parse(query["roomId"])))
        {
            context.Result = new OkResult();
            return;
        }
        context.Result = new BadRequestResult();
    }


}

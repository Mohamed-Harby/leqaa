using System.Security.Claims;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using BusinessLogic.Infrastructure.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using BusinessLogic.Domain.DomainErrors;

namespace BusinessLogic.Infrastructure.Authorization.Handlers;
public class CanJoinRoomAuthorizationHandler : AuthorizationHandler<CanJoinRoomRequirement>
{
    private IUserRepository _userRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public CanJoinRoomAuthorizationHandler(IUserRepository userRepository, IHttpContextAccessor httpContext)
    {
        _userRepository = userRepository;
        _httpContextAccessor = httpContext;
    }
    protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, CanJoinRoomRequirement requirement)
    {
        var query = _httpContextAccessor.HttpContext.Request.Query;
        string username = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        User user = await _userRepository.GetUserWithRoomsAsync(username);
        if (user is null)
        {
            context.Fail(new AuthorizationFailureReason(this, DomainErrors.User.NotFound.Description));
            return;
        }
        var userPermittedRooms = user.Rooms;
        var requiredRoomIdToJoin = Guid.Parse(query["roomId"]);
        if (user.Rooms!.Select(r => r.Id).Contains(requiredRoomIdToJoin))
        {
            context.Succeed(requirement);
            return;
        }
        context.Fail(new AuthorizationFailureReason(this, "You are not authorized to join this room ask the room owner for permission"));
    }
}

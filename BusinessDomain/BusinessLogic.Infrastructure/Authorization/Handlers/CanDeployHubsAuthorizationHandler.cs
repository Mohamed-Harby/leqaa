using System.Security.Claims;
using BusinessLogic.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using BusinessLogic.Domain.DomainErrors;
using BusinessLogic.Domain.Plan;
using BusinessLogic.Infrastructure.Authorization.Requirements;

namespace BusinessLogic.Infrastructure.Authorization.Handlers;
public class CanDeployHubsAuthorizationHandler : AuthorizationHandler<CanDeployHubsRequirements>
{
    private readonly IHubRepository _hubRepository;
    private readonly IUserRepository _userRepository;

    public CanDeployHubsAuthorizationHandler(IHubRepository hubRepository, IUserRepository userRepository)
    {
        _hubRepository = hubRepository;
        _userRepository = userRepository;
    }

    protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, CanDeployHubsRequirements requirements)
    {
        var userNameClaim = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier);
        if (userNameClaim is null)
        {
            context.Fail(new AuthorizationFailureReason(this, "Not authorized"));
            return;
        }
        var user = await _userRepository.GetUserWithPlansAsync(userNameClaim.Value);
        if (user is null)
        {
            context.Fail(new AuthorizationFailureReason(this, DomainErrors.User.NotFound.Description));
            return;
        }
        var plans = user.Plans;
        if (plans.Select(p => p.Type).Contains(PlanType.Premium))
        {
            context.Succeed(requirements);
            return;
        }
        context.Fail(new AuthorizationFailureReason(this, "You are not authorized to deploy hubs, consider upgrading you plan"));
    }
}
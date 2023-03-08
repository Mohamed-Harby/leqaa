using System.Security.Claims;
using BusinessLogic.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using BusinessLogic.Domain.DomainErrors;
using BusinessLogic.Domain.Plan;
using BusinessLogic.Infrastructure.Authorization.Requirements;
using BusinessLogic.Infrastructure.NetworkCalls;
using ErrorOr;
using Microsoft.AspNetCore.Http;

namespace BusinessLogic.Infrastructure.Authorization.Handlers;
public class CanDeployHubsAuthorizationHandler : AuthorizationHandler<CanDeployHubsRequirement>
{
    private readonly IHubRepository _hubRepository;
    private readonly IUserRepository _userRepository;
    private readonly HttpHelper _httpHelper;

    public CanDeployHubsAuthorizationHandler(IHubRepository hubRepository, IUserRepository userRepository, HttpHelper httpHelper)
    {
        _hubRepository = hubRepository;
        _userRepository = userRepository;
        _httpHelper = httpHelper;
    }

    protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, CanDeployHubsRequirement requirements)
    {
        var userNameClaim = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier);
        if (userNameClaim is null)
        {
            context.Fail(new AuthorizationFailureReason(this, "Not authorized"));
            await _httpHelper.WriteBody(DomainErrors.User.NotLogined, StatusCodes.Status401Unauthorized);
            return;
        }
        var user = await _userRepository.GetUserWithPlansWithHubsAsync(userNameClaim.Value);
        if (user is null)
        {
            context.Fail(new AuthorizationFailureReason(this, DomainErrors.User.NotFound.Description));
            await _httpHelper.WriteBody(DomainErrors.User.NotFound, StatusCodes.Status404NotFound);
            return;
        }
        var plans = user.Plans;
        var hubs = user.Hubs;
        if (hubs.Count >= 1)
        {
            context.Fail(new AuthorizationFailureReason(
                this,
                "Can't create more than one hub"));
            await _httpHelper.WriteBody(DomainErrors.User.CannotCreateMoreHubs, StatusCodes.Status403Forbidden);
            return;
        }
        if (!plans.Select(p => p.Type).Contains(PlanType.Premium))
        {
            context.Fail(new AuthorizationFailureReason(
                this,
                "You are not authorized to deploy hubs, consider upgrading your plan"));
            await _httpHelper.WriteBody(DomainErrors.User.InSufficentPlan, StatusCodes.Status403Forbidden);
            return;
        }
        context.Succeed(requirements);
    }
}
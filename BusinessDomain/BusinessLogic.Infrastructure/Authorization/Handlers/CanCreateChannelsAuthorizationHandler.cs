using System.Security.Claims;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Infrastructure.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;
using BusinessLogic.Domain.DomainErrors;
using BusinessLogic.Domain.Plan;

namespace BusinessLogic.Infrastructure.Authorization.Handlers;
public class CanCreateChannelAuthorizationHandler : AuthorizationHandler<CanCreateChannelsRequirement>
{
    private readonly IUserRepository _userRepository;
    private readonly IPlanRepository _planRepository;
    public CanCreateChannelAuthorizationHandler(IUserRepository userRepository, IPlanRepository planRepository)
    {
        _userRepository = userRepository;
        _planRepository = planRepository;
    }

    protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, CanCreateChannelsRequirement requirement)
    {
        var userNameClaim = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier);
        if (userNameClaim is null)
        {
            context.Fail(new AuthorizationFailureReason(this, "Not authorized"));
            return;
        }
        var user = await _userRepository.GetUserWithPlansWithChannelsAsync(userNameClaim.Value);
        if (user is null)
        {
            context.Fail(new AuthorizationFailureReason(this, DomainErrors.User.NotFound.Description));
            return;
        }
        var plans = user.Plans;
        var channels = user.Channels;
        if (channels.Count >= 37)
        {
            context.Fail(new AuthorizationFailureReason(
                this,
                "Can't create more than 37 channels"));
            return;
        }
        if (!plans.Select(p => p.Type).Contains(PlanType.Premium))
        {
            context.Fail(new AuthorizationFailureReason(
                this,
                "You are not authorized to Create channels, consider upgrading your plan"));
            return;
        }
        context.Succeed(requirement);



    }
}

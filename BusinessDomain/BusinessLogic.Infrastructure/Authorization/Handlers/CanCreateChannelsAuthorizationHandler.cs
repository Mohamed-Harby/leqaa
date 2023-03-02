using System.Security.Claims;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Infrastructure.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;
using BusinessLogic.Domain.DomainErrors;
using BusinessLogic.Domain.Plan;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using BusinessLogic.Application.Models.Channels;

namespace BusinessLogic.Infrastructure.Authorization.Handlers;
public class CanCreateChannelAuthorizationHandler : AuthorizationHandler<CanCreateChannelsRequirement>
{
    private readonly IUserRepository _userRepository;
    private readonly IPlanRepository _planRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public CanCreateChannelAuthorizationHandler(
        IUserRepository userRepository,
        IPlanRepository planRepository,
        IHttpContextAccessor httpContextAccessor)
    {
        _userRepository = userRepository;
        _planRepository = planRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, CanCreateChannelsRequirement requirement)
    {
        var userNameClaim = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier);
        if (userNameClaim is null)
        {
            context.Fail(new AuthorizationFailureReason(this, "Not authorized"));
            return;
        }
        _httpContextAccessor.HttpContext.Request.EnableBuffering();
        var requestBody = new StreamReader(_httpContextAccessor.HttpContext.Request.Body);
        var channelWriteModelSerialized = (await requestBody.ReadToEndAsync());
        var channelWriteModel = JsonConvert.DeserializeObject<ChannelWriteModel>(channelWriteModelSerialized)!;

        var user = (await _userRepository
                    .GetAsync(
                        u => u.UserName == userNameClaim.Value,
                         orderBy: null!, "Plans,Channels,Hubs"))
                    .FirstOrDefault();
        if (user is null)
        {
            context.Fail(new AuthorizationFailureReason(this, DomainErrors.User.NotFound.Description));
            return;
        }
        var plans = user.Plans;
        var channels = user.Channels;
        var hubs = user.Hubs;
        if (!(hubs.Select(h => h.Id).Any(guid => guid == channelWriteModel.HubId)) && channelWriteModel.HubId is not null)
        {
            context.Fail(new AuthorizationFailureReason(
               this,
               "You are not authorized to create channels in this hub, not authorized"));
            return;
        }
        _httpContextAccessor.HttpContext.Request.Body.Position = 0;
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

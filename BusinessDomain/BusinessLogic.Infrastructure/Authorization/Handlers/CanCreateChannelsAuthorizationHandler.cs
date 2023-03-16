using System.Security.Claims;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Infrastructure.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;
using BusinessLogic.Domain.DomainErrors;
using BusinessLogic.Domain.Plan;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Infrastructure.NetworkCalls;

namespace BusinessLogic.Infrastructure.Authorization.Handlers;
public class CanCreateChannelAuthorizationHandler : AuthorizationHandler<CanCreateChannelsRequirement>
{
    private readonly IUserRepository _userRepository;
    private readonly IPlanRepository _planRepository;
    private readonly HttpHelper _httpHelper;
    public CanCreateChannelAuthorizationHandler(
        IUserRepository userRepository,
        IPlanRepository planRepository,
        HttpHelper httpHelper)
    {
        _userRepository = userRepository;
        _planRepository = planRepository;
        _httpHelper = httpHelper;
    }

    protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, CanCreateChannelsRequirement requirement)
    {
        var userNameClaim = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier);
        if (userNameClaim is null)
        {
            context.Fail(new AuthorizationFailureReason(this, "Not authorized"));
            await _httpHelper.WriteBody(DomainErrors.User.NotLogined, StatusCodes.Status401Unauthorized);
            return;
        }
        _httpHelper.Request.EnableBuffering();
        var requestBody = new StreamReader(_httpHelper.Request.Body);
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
            await _httpHelper.WriteBody(DomainErrors.User.NotFound, StatusCodes.Status404NotFound);
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
            await _httpHelper.WriteBody(DomainErrors.User.NotFounderNorAdmin, StatusCodes.Status403Forbidden);
            return;
        }
        _httpHelper.Request.Body.Position = 0;
        if (channels.Count >= 37)
        {
            context.Fail(new AuthorizationFailureReason(
                this,
                "Can't create more than 37 channels"));
            await _httpHelper.WriteBody(DomainErrors.User.CannotCreateMoreChannels, StatusCodes.Status403Forbidden);
            return;
        }
        if (!plans.Select(p => p.Type).Contains(PlanType.Premium))
        {
            context.Fail(new AuthorizationFailureReason(
                this,
                "You are not authorized to Create channels, consider upgrading your plan"));
            await _httpHelper.WriteBody(DomainErrors.User.InSufficentPlan, StatusCodes.Status403Forbidden);
            return;
        }
        context.Succeed(requirement);
    }
}

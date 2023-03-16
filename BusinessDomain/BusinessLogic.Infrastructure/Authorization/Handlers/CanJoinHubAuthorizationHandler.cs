using System.Security.Claims;
using System.Text;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Infrastructure.Authorization.Requirements;
using BusinessLogic.Infrastructure.NetworkCalls;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BusinessLogic.Infrastructure.Authorization.Handlers;
public class CanJoinHubAuthorizationHandler : AuthorizationHandler<CanJoinHubRequirement>
{
    private readonly IHubRepository _hubRepository;
    private readonly IUserRepository _userRepository;
    private readonly HttpHelper _httpHelper;
    private readonly IUserHubRepository _userHubRepository;

    public CanJoinHubAuthorizationHandler(
        IHubRepository hubRepository,
        IUserRepository userRepository,
        IUserHubRepository userHubRepository,
        HttpHelper httpHelper)
    {
        _hubRepository = hubRepository;
        _userRepository = userRepository;
        _userHubRepository = userHubRepository;
        _httpHelper = httpHelper;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, CanJoinHubRequirement requirement)
    {
        Claim? userNameClaim = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier);

        List<Error> errorMessages = new List<Error> { };

        _httpHelper.HttpContext.Request.EnableBuffering();

        var response = _httpHelper.Response;
        var requestBody = new StreamReader(_httpHelper.Request.Body);

        var requestBodySerialized = await requestBody.ReadToEndAsync();

        if (userNameClaim is null)
        {
            errorMessages.Add(Error.Validation("User.UnAuthorized", "You are not authorized to join hubs, login first"));
            System.Console.WriteLine("Error at usernameclaim check");
            context.Fail(new AuthorizationFailureReason(this, "Not authorized"));
            await WriteBody(errorMessages, context, requirement);
            return;
        }

        var user = (await _userRepository.GetAsync(u => u.UserName == userNameClaim.Value, null!, "Hubs")).FirstOrDefault();

        if (user is null)
        {
            errorMessages.Add(Domain.DomainErrors.DomainErrors.User.NotFound);
            System.Console.WriteLine("Error at usernameclaim check");
            context.Fail(new AuthorizationFailureReason(this, "Not authorized"));
            await WriteBody(errorMessages, context, requirement);
            return;
        }

        var joinHubModel = JsonConvert.DeserializeObject<JoinHubModel>(requestBodySerialized);

        if (joinHubModel is null)
        {
            errorMessages.Add(Error.Validation("Hub.InvalidInput", "Invalid input, please check your input"));
            System.Console.WriteLine("Error at joinhubmodel check");
            context.Fail(new AuthorizationFailureReason(this, "invalid input"));
            await WriteBody(errorMessages, context, requirement);
            return;
        }

        var hub = await _hubRepository.GetByIdAsync(joinHubModel.Id);

        if (hub is null)
        {
            errorMessages.Add(Domain.DomainErrors.DomainErrors.Hub.NotFound);
            context.Fail(new AuthorizationFailureReason(this, "hub not found"));
            await WriteBody(errorMessages, context, requirement);
            return;
        }

        if (user.Hubs.Contains(hub))
        {
            await WriteBody(errorMessages, context, requirement);
            return;
        }

        if (hub.IsPrivate)
        {
            errorMessages.Add(Error.Failure(
                "User.UnAuthorized",
                "You are not authorized to join private hubs, ask the hub owner to let you in"));
            context.Fail(new AuthorizationFailureReason(this, "can't join private hub"));
            await WriteBody(errorMessages, context, requirement);
            return;
        }
        await WriteBody(errorMessages, context, requirement);
    }
    private Task WriteBody(List<Error> body, AuthorizationHandlerContext context, CanJoinHubRequirement requirement)
    {
        if (body.Count == 0)
        {
            context.Succeed(requirement);
            _httpHelper.Request.Body.Position = 0;
            return Task.CompletedTask;
        }
        _httpHelper.WriteBody(body, StatusCodes.Status403Forbidden);
        return Task.CompletedTask;
    }
}

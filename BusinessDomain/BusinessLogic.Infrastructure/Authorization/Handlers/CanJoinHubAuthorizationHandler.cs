using System.Security.Claims;
using System.Text;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Infrastructure.Authorization.Requirements;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BusinessLogic.Infrastructure.Authorization.Handlers;
public class CanJoinHubAuthorizationHandler : AuthorizationHandler<CanJoinHubRequirement>
{
    private readonly IHttpContextAccessor _httpAccessor;
    private readonly IHubRepository _hubRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUserHubRepository _userHubRepository;

    public CanJoinHubAuthorizationHandler(
        IHttpContextAccessor httpAccessor,
        IHubRepository hubRepository,
        IUserRepository userRepository,
        IUserHubRepository userHubRepository)
    {
        _httpAccessor = httpAccessor;
        _hubRepository = hubRepository;
        _userRepository = userRepository;
        _userHubRepository = userHubRepository;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, CanJoinHubRequirement requirement)
    {
        Claim? userNameClaim = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier);

        List<Error> responseMessage = new List<Error> { };

        _httpAccessor.HttpContext.Request.EnableBuffering();

        var response = _httpAccessor.HttpContext.Request.HttpContext.Response;
        var requestBody = new StreamReader(_httpAccessor.HttpContext.Request.Body);

        var requestBodySerialized = await requestBody.ReadToEndAsync();

        if (userNameClaim is null)
        {
            responseMessage.Add(Error.Validation("User.UnAuthorized", "You are not authorized to join hubs, login first"));
            System.Console.WriteLine("Error at usernameclaim check");
            context.Fail(new AuthorizationFailureReason(this, "Not authorized"));
            goto returnFunction;
        }

        var user = (await _userRepository.GetAsync(u => u.UserName == userNameClaim.Value, null!, "Hubs")).FirstOrDefault();

        if (user is null)
        {
            responseMessage.Add(Domain.DomainErrors.DomainErrors.User.NotFound);
            System.Console.WriteLine("Error at usernameclaim check");
            context.Fail(new AuthorizationFailureReason(this, "Not authorized"));
            goto returnFunction;
        }

        var joinHubModel = JsonConvert.DeserializeObject<JoinHubModel>(requestBodySerialized);

        if (joinHubModel is null)
        {
            responseMessage.Add(Error.Validation("Hub.InvalidInput", "Invalid input, please check your input"));
            System.Console.WriteLine("Error at joinhubmodel check");
            context.Fail(new AuthorizationFailureReason(this, "invalid input"));
            goto returnFunction;
        }

        var hub = await _hubRepository.GetByIdAsync(joinHubModel.Id);

        if (hub is null)
        {
            responseMessage.Add(Domain.DomainErrors.DomainErrors.Hub.NotFound);
            context.Fail(new AuthorizationFailureReason(this, "hub not found"));
            goto returnFunction;
        }

        if (user.Hubs.Contains(hub))
        {
            goto returnFunction;
        }

        if (hub.IsPrivate)
        {
            responseMessage.Add(Error.Failure(
                "User.UnAuthorized",
                "You are not authorized to join private hubs, ask the hub owner to let you in"));
            context.Fail(new AuthorizationFailureReason(this, "can't join private hub"));
            goto returnFunction;
        }

    returnFunction:
        /* 
           in this complex code the problem that 
           if the body is written to it can't be
           rewritten except using the writeAsync
           method again so when we checked if 
           there is no errors to not write to
           the response so that the response can
           be written elsewhere in the controller for
           example. it can be solved using memory 
           streams but will add more complexity
        */
        if (responseMessage.Count == 0)
        {
            context.Succeed(requirement);
            _httpAccessor.HttpContext.Request.Body.Position = 0;
            return;
        }
        string responseMessageSerialized = JsonConvert.SerializeObject(responseMessage);
        byte[] encodedReponseMessage = Encoding.UTF8.GetBytes(responseMessageSerialized);
        response.OnStarting(async () =>
           {
               response.ContentType = "application/json";
               response.StatusCode = StatusCodes.Status403Forbidden;
               await response.Body.WriteAsync(encodedReponseMessage, offset: 0, count: encodedReponseMessage.Length);
           });
    }
}

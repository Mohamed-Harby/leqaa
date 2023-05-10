using BusinessLogic.Infrastructure.Authorization.Enums;
using BusinessLogic.Infrastructure.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace BusinessLogic.Infrastructure.Authorization;
public class CanJoinRoomPolicyProvider : DefaultAuthorizationPolicyProvider
{
    public CanJoinRoomPolicyProvider(IOptions<AuthorizationOptions> options) : base(options)
    {
    }
    public async override Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        AuthorizationPolicy? policy = await base.GetPolicyAsync(policyName);
        if (policy is not null)
        {
            return policy;
        }
        return new AuthorizationPolicyBuilder()
        .AddRequirements(new CanDeployHubsRequirement(Permission.CanDeployHubs.ToString()))
        .AddRequirements(new CanCreateChannelsRequirement(Permission.CanCreateChannel.ToString()))
        // .AddRequirements(new CanJoinRoomRequirement(Permission.CanJoinRoom.ToString()))
        .Build();
    }
}

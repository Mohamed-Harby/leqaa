using BusinessLogic.Infrastructure.Authorization.Requirements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace BusinessLogic.Infrastructure.Authorization;
public class CanDeployHubsPolicyProvider : DefaultAuthorizationPolicyProvider
{
    public CanDeployHubsPolicyProvider(IOptions<AuthorizationOptions> options) : base(options)
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
        .AddRequirements(new CanDeployHubsRequirement(policyName))
        .Build();
    }
}

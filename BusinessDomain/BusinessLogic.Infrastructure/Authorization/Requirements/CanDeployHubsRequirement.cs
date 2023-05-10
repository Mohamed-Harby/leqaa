using BusinessLogic.Infrastructure.Authorization.Enums;
using Microsoft.AspNetCore.Authorization;

namespace BusinessLogic.Infrastructure.Authorization.Requirements;
public class CanDeployHubsRequirement : IAuthorizationRequirement
{
    public string Permission { get; set; } = string.Empty;
    public CanDeployHubsRequirement(string permission)
    {
        Permission = permission;
    }
}
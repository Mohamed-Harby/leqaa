using BusinessLogic.Infrastructure.Authorization.Enums;
using Microsoft.AspNetCore.Authorization;

namespace BusinessLogic.Infrastructure.Authorization.Requirements;
public class CanDeployHubsRequirements : IAuthorizationRequirement
{
    public string Permission { get; set; } = string.Empty;
    public CanDeployHubsRequirements(string permission)
    {
        Permission = permission;
    }
}
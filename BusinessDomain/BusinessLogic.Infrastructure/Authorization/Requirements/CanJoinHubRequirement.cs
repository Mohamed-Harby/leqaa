using BusinessLogic.Infrastructure.Authorization.Enums;
using Microsoft.AspNetCore.Authorization;

namespace BusinessLogic.Infrastructure.Authorization.Requirements;
public class CanJoinHubRequirement : IAuthorizationRequirement
{
    string Permission;
    public CanJoinHubRequirement(string permission)
    {
        Permission = permission;
    }
}
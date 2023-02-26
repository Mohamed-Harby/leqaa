using Microsoft.AspNetCore.Authorization;

namespace BusinessLogic.Infrastructure.Authorization.Requirements;
public class CanCreateChannelsRequirement : IAuthorizationRequirement
{
    public string Permission { get; set; } = string.Empty;
    public CanCreateChannelsRequirement(string permission)
    {
        Permission = permission;
    }
}
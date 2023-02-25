using BusinessLogic.Domain;
using Microsoft.AspNetCore.Authorization;

namespace BusinessLogic.Infrastructure.Authorization.Requirements;
public class CanJoinRoomRequirement : IAuthorizationRequirement
{
    public string Permission { get; set; } = string.Empty;
    public CanJoinRoomRequirement(string permission)
    {
        Permission = permission;
    }

}
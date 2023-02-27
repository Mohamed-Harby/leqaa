using BusinessLogic.Infrastructure.Authorization.Enums;
using Microsoft.AspNetCore.Authorization;

namespace BusinessLogic.Infrastructure.Authorization;
public class HasPermissionAttribute : AuthorizeAttribute
{
    public HasPermissionAttribute(Permission permission) : base(policy: permission.ToString())
    {

    }
}
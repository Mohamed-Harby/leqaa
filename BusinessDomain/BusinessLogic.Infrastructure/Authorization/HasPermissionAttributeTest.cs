using Microsoft.AspNetCore.Authorization;

namespace BusinessLogic.Infrastructure.Authorization;
public class HasPermissionTestAttribute : AuthorizeAttribute
{
    public HasPermissionTestAttribute(string permission) : base(policy: permission)
    {

    }
}
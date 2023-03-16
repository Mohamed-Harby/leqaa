using Authentication.Domain.Entities.ApplicationUser.Enums;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Domain.Entities.ApplicationUser
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
        public Gender Gender { get; set; }

    }
}

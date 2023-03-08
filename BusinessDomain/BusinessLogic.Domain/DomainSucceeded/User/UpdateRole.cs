using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorOr;
namespace BusinessLogic.Domain.DomainSucceeded.User
{



    public static partial class DomainSucceded
    {
        public static class User
        {
            public static Error RoleAdded => Error.NotFound("User.roleAdded", "Role added successfully");

        }

    }
}
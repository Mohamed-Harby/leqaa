using ErrorOr;
namespace BusinessLogic.Domain.DomainSucceeded.User
{



    public static partial class DomainSucceded
    {
        public static class User
        {
            public static Error RoleAdded => Error.NotFound("User.roleAdded", "Role added successfully");

            public static Error HubLeft => Error.NotFound("User.HubLeft", "hub left ");

            public static Error ChannelLeft => Error.NotFound("User.ChannelLeft", "Channel left ");


        }

    }
}
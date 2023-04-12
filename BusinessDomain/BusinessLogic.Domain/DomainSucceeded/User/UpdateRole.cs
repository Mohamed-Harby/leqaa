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

            public static Error ChannelUnPinned=> Error.NotFound("User.ChannelUnPinned", "Channel un pinned ");
            public static Error HubUnPinned => Error.NotFound("User.HubUnPinned", "hub un pinned ");
            public static Error ChannelDeleted => Error.NotFound("User.ChannelDeleted", "channel deleted ");
            

            public static Error HubLeftAndDeleted => Error.NotFound("User.HubLeftAndDeleted", "Hub Left And Deleted ");

        }

    }
}
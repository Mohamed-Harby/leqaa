using ErrorOr;

namespace BusinessLogic.Domain.DomainErrors;
public static partial class DomainErrors
{
    public static partial class UserUser
    {
        public static Error AlreadyFollowed => Error.Conflict("FollowUser.AlreadyFollowed", "You have already followed that user");
    }
}
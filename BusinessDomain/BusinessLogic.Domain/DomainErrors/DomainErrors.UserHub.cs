using ErrorOr;

namespace BusinessLogic.Domain.DomainErrors;
public static partial class DomainErrors
{
    public static partial class UserHub
    {
        public static Error AlreadyJoined => Error.Conflict("UserHub.AlreadyJoined", "You have already joined this hub");
    }
}
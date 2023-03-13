using ErrorOr;

namespace BusinessLogic.Domain.DomainErrors;
public static partial class DomainErrors
{
    public static partial class UserHub
    {
        public static Error AlreadyJoined => Error.Conflict("UserHub.AlreadyJoined", "You have already joined this hub");

        public static Error CouldNotProceed => Error.Conflict("UserHub.CouldNotProceed", "could not proceed this action");
        public static Error NotJoined => Error.Conflict("UserHub.NotJoined", "User not joined to this hub");


    }
}
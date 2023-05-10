using ErrorOr;

namespace BusinessLogic.Domain.Common.Errors;
public static partial class DomainErrors
{
    public static class Hub
    {
        public static Error InvalidHub => Error.Failure("Hub.InvalidHub", "Invalid hub, couldn't complete your request");
        public static Error NotFound => Error.NotFound("Hub.NotFound", "Hub not found, create hub");
        public static Error CannotJoinHub => Error.Failure("Hub.CannotJoin", "Can't join hub, please check your input");

        public static Error AlreadyExest => Error.Failure("Hub.AlreadyExest", "hub aleaready exists");

        public static Error CannotLeaveHub => Error.Failure("Hub.CannotLeaveHub", "cant't leave hub because there are no other users");


    }
}
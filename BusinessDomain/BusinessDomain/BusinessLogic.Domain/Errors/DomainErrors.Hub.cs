using ErrorOr;

namespace BusinessLogic.Domain.DomainErrors;
public static partial class DomainErrors
{
    public static class Hub
    {
        public static Error InvalidHub => Error.Failure("Hub.InvalidHub", "Invalid hub, couldn't complete your request");
        public static Error NotFound => Error.NotFound("Hub.NotFound", "Hub not found, create hub");
    }
}
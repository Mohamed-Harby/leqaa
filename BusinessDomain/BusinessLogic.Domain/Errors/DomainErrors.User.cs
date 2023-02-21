using ErrorOr;

namespace BusinessLogic.Domain.DomainErrors;
public static partial class DomainErrors
{
    public static class User
    {
        public static Error DuplicateUsername => Error.Conflict("User.InvalidUsername", "Invalid username");
        public static Error DuplicateEmail => Error.Conflict("User.InvalidEmail", "Invalid email address");
        public static Error NotFound => Error.NotFound("User.NotFound", "User not found, register");

    }
}
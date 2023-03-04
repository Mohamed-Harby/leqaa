using ErrorOr;

namespace BusinessLogic.Domain.DomainErrors;
public static partial class DomainErrors
{
    public static class User
    {
        public static Error DuplicateUsername => Error.Conflict(
            "User.InvalidUsername",
            "Invalid username");
        public static Error DuplicateEmail => Error.Conflict(
            "User.InvalidEmail",
            "Invalid email address");
        public static Error NotFound => Error.NotFound(
            "User.NotFound",
            "User not found, register");
        public static Error InvalidFollowedUser => Error.Failure(
            "User.InvalidFollowedUser",
            "Can't follow this user, please check the user you're trying to follow");

    }
}
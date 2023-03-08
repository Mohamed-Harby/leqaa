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
        public static Error NotLogined => Error.Failure(
            "User.NotLogined",
            "You are not authorized to perform this action, please login");
        public static Error CannotCreateMoreHubs => Error.Failure(
            "User.CannotCreateMoreHubs",
            "Can't create more hubs, you have reached the maximum number of hubs you can create");
        public static Error InSufficentPlan => Error.Failure(
            "User.InSufficentPlan",
            "Can't create hub nor channels, consider upgrading your plan");
        public static Error NotFounderNorAdmin => Error.Failure(
            "User.NotFounderNorAdmin",
            "You are not authorized to perform this action, you are neither the founder nor an admin");
        public static Error CannotCreateMoreChannels => Error.Failure(
            "User.CannotCreateMoreChannels",
            "Can't create more channels, you can't create more than 37 channels");

        public static Error UserDontHavePermession => Error.Failure(
           "User.UserDontHavePermession",
           "user don't have permission to take this action");

    }
}
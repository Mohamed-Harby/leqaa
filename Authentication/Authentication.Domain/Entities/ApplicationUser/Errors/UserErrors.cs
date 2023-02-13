namespace Authentication.Domain.Entities.ApplicationUser.Errors;
public static class UserErrors
{
    public static string EmailAlreadyExists => "Email already exists, please login";
    public static string EmailDoesNotExist => "User with this email does not exist";
    public static string UserNameAlreadyExists => "Username already exists, please login";
}
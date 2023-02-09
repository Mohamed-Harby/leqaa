using Authentication.Application.CommandInterfaces;

namespace Authentication.Application.Queries.SendEmailChangePassword;
public record SendEmailChangePasswordQuery(
    string Email,
    string ChangePasswordLink
) : IQuery;
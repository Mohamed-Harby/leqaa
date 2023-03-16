using Authentication.Application.CommandInterfaces;

namespace Authentication.Application.Queries.SendEmailResetPassword;
public record SendEmailResetPasswordQuery(
    string Email
) : IQuery;
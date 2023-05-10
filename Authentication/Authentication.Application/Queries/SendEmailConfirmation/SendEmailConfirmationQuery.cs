using Authentication.Application.CommandInterfaces;

namespace Authentication.Application.Queries.SendEmailConfirmation;
public record SendEmailConfirmationQuery(
    string Email,
    string ConfirmationLink
) : IQuery;
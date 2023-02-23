
using Authentication.Application.CommandInterfaces;

namespace Authentication.Application.Commands.ConfirmEmail;
public record ConfirmEmailCommand(
    string Email,
    string Token
) : ICommand;
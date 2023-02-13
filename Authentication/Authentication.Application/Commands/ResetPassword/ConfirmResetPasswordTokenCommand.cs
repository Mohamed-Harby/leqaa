using Authentication.Application.CommandInterfaces;

namespace Authentication.Application.Commands.ConfirmResetPasswordToken;
public record ResetPasswordCommand(
    string Email,
    string Token,
    string NewPassword
) : ICommand;
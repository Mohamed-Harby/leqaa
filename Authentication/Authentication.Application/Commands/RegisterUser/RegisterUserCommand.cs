using Authentication.Application.CommandInterfaces;
using Authentication.Domain.Entities.ApplicationUser.Enums;

namespace Authentication.Application.Commands.RegisterUser;
public record RegisterUserCommand(
    string UserName,
    string Password,
    string Email,
    Gender Gender,
    string Name,
    string ConfirmationLink
) : ICommand;
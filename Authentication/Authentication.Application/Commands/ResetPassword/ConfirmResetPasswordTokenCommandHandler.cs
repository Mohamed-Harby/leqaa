using Authentication.Application.CommandInterfaces;
using Authentication.Application.Commands.ConfirmResetPasswordToken;
using Authentication.Application.Models;
using Authentication.Domain.Entities.ApplicationUser;
using Authentication.Domain.Entities.ApplicationUser.Errors;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Application.Commands.ResetPassword;
public class ConfirmResetPasswordTokenCommandHandler : IHandler<ResetPasswordCommand>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public ConfirmResetPasswordTokenCommandHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }
    public async Task<Results> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var authenticationResults = new Results();
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (!user.EmailConfirmed)
        {
            authenticationResults.ErrorMessages.Add("you email is not confirmed please confirm it first");
            return authenticationResults;
        }
        if (user is null)
        {
            authenticationResults.AddErrorMessages(UserErrors.EmailDoesNotExist);
            return authenticationResults;
        }
        var result = await _userManager.ResetPasswordAsync(user, request.Token, request.NewPassword);
        if (!result.Succeeded)
        {
            authenticationResults.AddErrorMessages(result.Errors.Select(e => e.Description).ToArray());
            return authenticationResults;
        }
        authenticationResults.IsSuccess = true;
        return authenticationResults;
    }
}

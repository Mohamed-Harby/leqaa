using Authentication.Application.CommandInterfaces;
using Authentication.Application.Interfaces;
using Authentication.Application.Models;
using Authentication.Domain.Entities.ApplicationUser;
using Authentication.Domain.Entities.ApplicationUser.Errors;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Application.Queries.SendEmailResetPassword;
public class SendEmailResetPasswordQueryHandler : IHandler<SendEmailResetPasswordQuery>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IResetPasswordEmailSender _emailSender;
    public SendEmailResetPasswordQueryHandler(UserManager<ApplicationUser> userManager, IResetPasswordEmailSender resetPasswordEmailSender)
    {
        _userManager = userManager;
        _emailSender = resetPasswordEmailSender;
    }

    public async Task<Results> Handle(SendEmailResetPasswordQuery request, CancellationToken cancellationToken)
    {
        var authenticationResults = new Results();
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            authenticationResults.AddErrorMessages(UserErrors.EmailDoesNotExist);
            return authenticationResults;
        }
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        try
        {
            await _emailSender.SendPasswordResetAsync(toEmail: request.Email, token);
            authenticationResults.IsSuccess = true;
        }
        catch
        {
            authenticationResults.AddErrorMessages("Couldn't send change password email");
        }
        return authenticationResults;
    }
}

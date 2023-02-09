using Authentication.Application.CommandInterfaces;
using Authentication.Application.Interfaces;
using Authentication.Application.Models;
using Authentication.Domain.Entities.ApplicationUser;
using Authentication.Domain.Entities.ApplicationUser.Errors;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Application.Queries.SendEmailChangePassword;
public class SendEmailChangePasswordQueryHandler : IHandler<SendEmailChangePasswordQuery>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IEmailSender _emailSender;


    public SendEmailChangePasswordQueryHandler(UserManager<ApplicationUser> userManager, IServiceProvider serviceProvider)
    {
        _userManager = userManager;
        _emailSender = serviceProvider.GetServices<IEmailSender>().First(s => s.GetType().Name.Contains("password"));
    }

    public async Task<Results> Handle(SendEmailChangePasswordQuery request, CancellationToken cancellationToken)
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
            await _emailSender.SendAsync(toEmail: request.Email, request.ChangePasswordLink, token);
            authenticationResults.IsSuccess = true;
        }
        catch
        {
            authenticationResults.AddErrorMessages("Couldn't send change password email");
        }
        return authenticationResults;
    }
}

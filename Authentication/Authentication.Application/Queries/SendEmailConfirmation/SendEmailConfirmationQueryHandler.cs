using System.Web;
using Authentication.Application.CommandInterfaces;
using Authentication.Application.Interfaces;
using Authentication.Application.Models;
using Authentication.Domain.Entities.ApplicationUser;
using Authentication.Domain.Entities.ApplicationUser.Errors;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Application.Queries.SendEmailConfirmation;
public class SendEmailConfirmationQueryHandler : IHandler<SendEmailConfirmationQuery>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IEmailSender _emailSender;

    public SendEmailConfirmationQueryHandler(
        UserManager<ApplicationUser> userManager,
        IConfiguration configuration,
        IServiceProvider serviceProvider)
    {
        _userManager = userManager;
        _emailSender = serviceProvider.GetServices<IEmailSender>().First(o => o.GetType().Name.Contains("confirmation"));
        _configuration = configuration;
    }

    public async Task<Results> Handle(SendEmailConfirmationQuery request, CancellationToken cancellationToken)
    {
        var authenticationResults = new Results();
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            authenticationResults.AddErrorMessages(UserErrors.EmailDoesNotExist);
            return authenticationResults;
        }
        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        try
        {
            await _emailSender.SendAsync(toEmail: request.Email, request.ConfirmationLink, token);
            authenticationResults.IsSuccess = true;
        }
        catch
        {
            authenticationResults.AddErrorMessages("Couldn't send confirmation email");
        }
        return authenticationResults;
    }
}

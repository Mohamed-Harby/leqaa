using System.Web;
using Authentication.Application.CommandInterfaces;
using Authentication.Application.Models;
using Authentication.Domain.Entities.ApplicationUser;
using Authentication.Domain.Entities.ApplicationUser.Errors;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Application.Commands.ConfirmEmail;
public class ConfirmEmailCommandHandler : IHandler<ConfirmEmailCommand>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public ConfirmEmailCommandHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Results> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
    {
        var authenticationResults = new Results();
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user is null)
        {
            authenticationResults.AddErrorMessages(UserErrors.EmailDoesNotExist);
            return authenticationResults;
        }
        var result = await _userManager.ConfirmEmailAsync(user, request.Token);
        if (!result.Succeeded)
        {
            authenticationResults.AddErrorMessages(result.Errors.Select(e => e.Description).ToArray());
            return authenticationResults;
        }


        authenticationResults.IsSuccess = true;
    

        return authenticationResults;
    }
}
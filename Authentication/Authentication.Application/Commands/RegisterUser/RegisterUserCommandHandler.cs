using Authentication.Application.CommandInterfaces;
using Authentication.Application.Interfaces;
using Authentication.Application.Models;
using Authentication.Domain.Entities.ApplicationUser;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Application.Commands.RegisterUser;
public class RegisterUserCommandHandler : IHandler<RegisterUserCommand>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ITokenGenerator _tokenGenerator;
    private readonly IEmailSender _emailSender;

    public RegisterUserCommandHandler(
        UserManager<ApplicationUser> userManager,
        IServiceProvider serviceProvider,
        ITokenGenerator tokenGenerator
        )
    {
        _emailSender = serviceProvider.GetServices<IEmailSender>().First(s => s.GetType().Name.Contains("onfirmation"));
        _userManager = userManager;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<Results> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var authenticationResults = new Results();
        var user = request.Adapt<ApplicationUser>();
        if (await _userManager.FindByNameAsync(user.UserName) is not null)
        {
            authenticationResults.AddErrorMessages("Username already exists, please login");
        }
        if (await _userManager.FindByEmailAsync(user.Email) is not null)
        {
            authenticationResults.AddErrorMessages("Email already exists, please login");
        }
        if (authenticationResults.ErrorMessages.Count > 0)
            return authenticationResults;

        var resultTask = _userManager.CreateAsync(user, request.Password);

        string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        try
        {

            await _emailSender.SendAsync(request.Email, request.ConfirmationLink, token);
            authenticationResults.IsSuccess = true;
        }
        catch
        {
            authenticationResults.AddErrorMessages("Couldn't send confirmation email, try to confirm your email later");
        }
        var result = await resultTask;
        if (!result.Succeeded)
        {
            authenticationResults.AddErrorMessages(result.Errors.Select(e => e.Description).ToArray());
            return authenticationResults;
        }

        authenticationResults.IsSuccess = true;
        authenticationResults.SetToken(_tokenGenerator.Generate(user)); //TODO : remove for business needs if needed

        return authenticationResults;
    }
}

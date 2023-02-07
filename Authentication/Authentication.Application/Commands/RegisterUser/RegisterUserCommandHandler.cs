using Authentication.Application.CommandInterfaces;
using Authentication.Application.Interfaces;
using Authentication.Application.Models;
using Authentication.Domain.Entities.ApplicationUser;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Application.Commands.RegisterUser;
public class RegisterUserCommandHandler : IHandler<RegisterUserCommand>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ITokenGenerator _tokenGenerator;

    public RegisterUserCommandHandler(
        UserManager<ApplicationUser> userManager,
        ITokenGenerator tokenGenerator)
    {
        _userManager = userManager;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<AuthenticationResults> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var authenticationResults = new AuthenticationResults();
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

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            authenticationResults.AddErrorMessages(result.Errors.Select(e => e.Description).ToArray());
            return authenticationResults;
        }

        authenticationResults.IsSuccess = true;
        authenticationResults.SetToken(_tokenGenerator.Generate(user));

        return authenticationResults;
    }
}

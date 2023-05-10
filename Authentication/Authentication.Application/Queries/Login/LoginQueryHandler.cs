using Authentication.Application.CommandInterfaces;
using Authentication.Application.Interfaces;
using Authentication.Application.Models;
using Authentication.Domain.Entities.ApplicationUser;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Application.Queries.Login;
public class LoginQueryHandler : IHandler<LoginQuery>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ITokenGenerator _tokenGenerator;

    public LoginQueryHandler(UserManager<ApplicationUser> userManager, ITokenGenerator tokenGenerator)
    {
        _userManager = userManager;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<Results> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var authenticationResults = new Results();
        var user = await _userManager.FindByNameAsync(request.UserName);
        if (user is null)
        {
            authenticationResults.AddErrorMessages("username doesn't exist, Please register");
            return authenticationResults;
        }
        if (!await _userManager.CheckPasswordAsync(user, request.Password))
        {
            authenticationResults.AddErrorMessages("Incorrect password");
            return authenticationResults;
        }

        if (!user.EmailConfirmed)
        {
            authenticationResults.AddErrorMessages("you email is not confirmed please confirm it first");
            return authenticationResults;
        }
        var token = _tokenGenerator.Generate(user);
        authenticationResults.SetToken(token);
        authenticationResults.IsSuccess = true;
        authenticationResults.User = user.Adapt<UserReadModel>();
        return authenticationResults;
    }
}

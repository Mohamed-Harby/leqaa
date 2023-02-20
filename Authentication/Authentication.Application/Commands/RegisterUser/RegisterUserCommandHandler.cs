using Authentication.Application.CommandInterfaces;
using Authentication.Application.Interfaces;
using Authentication.Application.Models;
using Authentication.Domain.Entities.ApplicationUser;
using Authentication.Domain.Entities.ApplicationUser.Errors;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace Authentication.Application.Commands.RegisterUser;
public class RegisterUserCommandHandler : IHandler<RegisterUserCommand>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ITokenGenerator _tokenGenerator;
    private readonly IConfirmationEmailSender _emailSender;
    private readonly IMessageQueueManager _messageQueueManager;

    public RegisterUserCommandHandler(
        UserManager<ApplicationUser> userManager,
        IConfirmationEmailSender confirmationEmailSender,
        ITokenGenerator tokenGenerator
,
        IMessageQueueManager messageQueueManager)
    {
        _emailSender = confirmationEmailSender;
        _userManager = userManager;
        _tokenGenerator = tokenGenerator;
        _messageQueueManager = messageQueueManager;
    }

    public async Task<Results> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var authenticationResults = new Results();
        var user = request.Adapt<ApplicationUser>();
        if (await _userManager.FindByNameAsync(user.UserName) is not null)
        {
            authenticationResults.AddErrorMessages(UserErrors.UserNameAlreadyExists);
        }
        if (await _userManager.FindByEmailAsync(user.Email) is not null)
        {
            authenticationResults.AddErrorMessages(UserErrors.EmailAlreadyExists);
        }
        if (authenticationResults.ErrorMessages.Count > 0)
            return authenticationResults;

        var resultTask = _userManager.CreateAsync(user, request.Password);

        string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        try
        {
            await _emailSender.SendConfirmationAsync(request.Email, request.ConfirmationLink, token);
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
        var userReadModel = user.Adapt<UserReadModel>();
        _messageQueueManager.PublishUser(userReadModel);
        authenticationResults.IsSuccess = true;
        authenticationResults.SetToken(_tokenGenerator.Generate(user)); //TODO : remove for business needs if needed

        return authenticationResults;
    }
}

using Authentication.Application.Commands.ConfirmEmail;
using Authentication.Application.Commands.RegisterUser;
using Authentication.Application.Models;
using Authentication.Application.Queries.Login;
using Authentication.Application.Queries.SendEmailConfirmation;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Presentation.Controllers;
[ApiController]
[Route("api/v1/[controller]/[action]")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class AuthenticationController : ControllerBase
{
    private readonly ISender _sender;
    public AuthenticationController(ISender sender)
    {
        _sender = sender;
    }
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register(UserWriteModel userWriteModel)
    {
        var registerUserCommand = userWriteModel.Adapt<RegisterUserCommand>();
        registerUserCommand = registerUserCommand with
        {
            ConfirmationLink = Url.Action(nameof(ConfirmEmail))
        };
        Results results = await _sender.Send(registerUserCommand);
        if (!results.IsSuccess)
            return BadRequest(results);
        return Ok(results);
    }
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginCredentials credentials)
    {
        var loginQuery = credentials.Adapt<LoginQuery>();
        Results results = await _sender.Send(loginQuery);
        if (!results.IsSuccess)
            return BadRequest(results);
        return Ok(results);
    }
    [Authorize]
    [HttpGet]
    public IActionResult CheckIfAuthenticated()
    {
        return Ok("You are authenticated");
    }
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> SendConfirmationEmail(string email)
    {
        var emailConfirmationQuery = new SendEmailConfirmationQuery(email, Url.Action(nameof(ConfirmEmail)));
        var results = await _sender.Send(emailConfirmationQuery);
        if (!results.IsSuccess)
            return BadRequest(results);
        return Ok(results);
    }
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> ConfirmEmail(string email, string token)
    {
        var confirmEmailCommand = new ConfirmEmailCommand(email, token);
        var results = await _sender.Send(confirmEmailCommand);
        if (!results.IsSuccess)
            return BadRequest(results);
        return Ok(results);
    }

}
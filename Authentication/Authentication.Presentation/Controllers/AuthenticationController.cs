using Authentication.Application.Commands.ConfirmEmail;
using Authentication.Application.Commands.ConfirmResetPasswordToken;
using Authentication.Application.Commands.RegisterUser;
using Authentication.Application.Models;
using Authentication.Application.Queries.Login;
using Authentication.Application.Queries.SendEmailResetPassword;
using Authentication.Application.Queries.SendEmailConfirmation;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Authentication.Application.Queries.GetUserByUsername;
using System.Security.Claims;

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
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetUser()
    {
        string username = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        if (username is null)
        {
            return Unauthorized("you are not authorized");
        }
        var getUserByUsernameQuery = new GetUserByUsername(username);
        Results results = await _sender.Send(getUserByUsernameQuery);
        if (!results.IsSuccess)
            return BadRequest(results);
        return Ok(results);
    }
    [HttpGet]
    [Authorize]
    public IActionResult CheckIfAuthenticated()
    {
        return Ok("You are authenticated");
    }
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> SendConfirmationEmail(string email)
    {
        var emailConfirmationQuery = new SendEmailConfirmationQuery(email, Url.Action(nameof(ConfirmEmail)));
        var results = await _sender.Send(emailConfirmationQuery);
        if (!results.IsSuccess)
            return BadRequest(results);
        return Ok(results);
    }
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> SendResetPasswordEmail(string email)
    {
        var emailResetPasswordQuery = new SendEmailResetPasswordQuery(email);
        var results = await _sender.Send(emailResetPasswordQuery);
        if (!results.IsSuccess)
            return BadRequest(results);
        return Ok(results);
    }
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailCommand confirmEmailRequest)
    {
        var results = await _sender.Send(confirmEmailRequest);
        if (!results.IsSuccess)
            return BadRequest(results);
        return Ok(results);
    }
    [HttpPut]
    [AllowAnonymous]
    public async Task<IActionResult> ResetPassword(ResetPasswordCommand resetPasswordRequest)
    {

        var results = await _sender.Send(resetPasswordRequest);
        if (!results.IsSuccess)
            return BadRequest(results);
        return Ok(results);
    }

}
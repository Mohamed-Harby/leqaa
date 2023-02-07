using Authentication.Application.Commands.RegisterUser;
using Authentication.Application.Models;
using Authentication.Application.Queries.LoginQuery;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Presentation.Controllers;
[ApiController]
[Route("[controller]/[action]")]
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
        AuthenticationResults results = await _sender.Send(registerUserCommand);
        if (!results.IsSuccess)
            return BadRequest(results);
        return Ok(results);
    }
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Login(LoginCredentials credentials)
    {
        var loginQuery = credentials.Adapt<LoginQuery>();
        AuthenticationResults results = await _sender.Send(loginQuery);
        if (!results.IsSuccess)
            return BadRequest(results);
        return Ok(results);
    }
    [Authorize]
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("You are authenticated");
    }
}
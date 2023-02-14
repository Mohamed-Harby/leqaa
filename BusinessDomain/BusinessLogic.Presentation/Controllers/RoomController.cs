using BusinessLogic.Domain;
using BusinessLogic.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using BusinessLogic.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using BusinessLogic.Infrastructure.Authorization;

namespace BusinessLogic.Presentation.Controllers;
[Authorize(AuthenticationSchemes = "Bearer")]
public class RoomController : BaseController
{
    private readonly ISender _sender;
    private readonly ILogger<HubController> _logger;
    public IUserRepository _userRepository;

    public RoomController(ISender sender, ILogger<HubController> logger, IUserRepository userRepository)
    {
        _sender = sender;
        _logger = logger;
        _userRepository = userRepository;
    }


    [Authorize]
    [HasPermission]
    [HttpGet]
    public async Task<IActionResult> GetRoom(string roomId)
    {
        return Ok("You can join this room");
    }


}
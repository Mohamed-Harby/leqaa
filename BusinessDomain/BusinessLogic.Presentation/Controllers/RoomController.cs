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
using BusinessLogic.Application.Queries.Hubs.GetAllHubs;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BusinessLogic.Application.Queries.Rooms.ViewRooms;
using BusinessLogic.Infrastructure.Authorization.Enums;
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
    [HasPermission(Permission.CanJoinRoom)]
    [HttpGet]
    public async Task<IActionResult> GetRoom(string roomId)
    {
        return Ok("You can join this room");
    }

    [HttpGet]
    public async Task<IActionResult> ViewRooms([FromQuery] string cursor, int limit = 10)
    {
        var query = new ViewRoomsQuery(limit, cursor);
        var rooms = await _sender.Send(query);

        return Ok(rooms);
    }
}
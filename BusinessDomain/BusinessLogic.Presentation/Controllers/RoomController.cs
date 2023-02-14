
using BusinessLogic.Application.Commands.Channels.AddChannel;
using BusinessLogic.Application.Commands.Rooms.AddRoom;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Application.Models.Rooms;
using BusinessLogic.Domain;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogic.Presentation.Controllers;
[ApiController]
[Route("api/v1/[controller]/[action]")]
public class RoomController : BaseController
{
    private readonly ISender _sender;

    public RoomController(ISender sender)
    {
        _sender = sender;
    }
    [HttpPost]
    public async Task<IActionResult> Post(RoomWriteModel roomWriteModel, string username)
    {
        var addRoomCommand = new AddRoomCommand(
            roomWriteModel.name,
            roomWriteModel.description,
           roomWriteModel.hubId,
           roomWriteModel.channelId,
           
            username);

        ErrorOr<Room> result = await _sender.Send(addRoomCommand);
        return result.Match(
             room => Ok(roomWriteModel),//TODO : change this later
             errors => Problem(errors)
         );

    }
}
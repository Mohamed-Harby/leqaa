using System.Security.Claims;
using BusinessLogic.Application.Commands.Channels.CreateChannel;
using BusinessLogic.Application.Commands.Channels.DeleteChannel;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Queries.channels.ViewChannels;

using BusinessLogic.Infrastructure.Authorization;
using BusinessLogic.Infrastructure.Authorization.Enums;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogic.Presentation.Controllers;
[ApiController]
[Route("api/v1/[controller]/[action]")]
public class ChannelController : BaseController
{
    private readonly ISender _sender;
    public ChannelController(ISender sender)
    {
        _sender = sender;
    }
    [HttpPost]
    [HasPermission(Permission.CanCreateChannel)]
    public async Task<IActionResult> CreateChannel(ChannelWriteModel channelWriteModel)
    {
        var username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

        var addChannelCommand = new CreateChannelCommand(
            channelWriteModel.Name,
            channelWriteModel.Description,
            channelWriteModel.HubId,
            username);

        ErrorOr<ChannelReadModel> result = await _sender.Send(addChannelCommand);
        return result.Match(
             channel => Ok(channel),
             errors => Problem(errors)
         );

    }

    /*[HttpGet]
    public async Task<IEnumerable<GetAllChannelsQuery>> ViewChannels()
    {
        var result =new List<GetAllChannelsQuery>();
        await _sender.Send(result);
        return result;

    }
*/

    [HttpGet]
    public async Task<IActionResult> ViewChannels([FromQuery] string cursor, int limit = 10)
    {
        var query = new ViewRoomQuery(limit, cursor);
        var channels = await _sender.Send(query);

        return Ok(channels);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {

        var DeleteModel=new DeletePostCommand(id);
        await _sender.Send(DeleteModel);

        return NoContent();
    }
}
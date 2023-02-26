using BusinessLogic.Application.Commands.Channels.AddChannel;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Queries.channels.ViewChannels;

using BusinessLogic.Domain;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public async Task<IActionResult> Post(ChannelWriteModel channelWriteModel, string username)
    {
        var addChannelCommand = new AddChannelCommand(
            channelWriteModel.name,
            channelWriteModel.description,
         channelWriteModel.ChannelId,
         channelWriteModel.hubId,
       
            username);

        ErrorOr<Channel> result = await _sender.Send(addChannelCommand);
        return result.Match(
             channel => Ok(channelWriteModel),//TODO
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
        var query = new ViewRoomQuery(limit,cursor);
        var channels = await _sender.Send(query);

        return Ok(channels);
    }
}
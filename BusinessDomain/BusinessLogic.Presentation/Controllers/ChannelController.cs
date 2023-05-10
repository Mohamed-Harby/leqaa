using System.Security.Claims;
using BusinessLogic.Application.Commands.Channels.CreateChannel;
using BusinessLogic.Application.Commands.Channels.DeleteChannel;
using BusinessLogic.Application.Commands.Channels.UpdateChannel;
using BusinessLogic.Application.Models;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Queries.channels.ViewChannels;
using BusinessLogic.Application.Queries.Channels.ViewChannel;
using BusinessLogic.Application.Queries.Channels.ViewRecentActivities;
using BusinessLogic.Application.Queries.Channels.GetChannelMembers;
using BusinessLogic.Infrastructure.Authorization;
using BusinessLogic.Infrastructure.Authorization.Enums;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BusinessLogic.Application.Models.Users;
using BusinessLogic.Application.Queries.Channels.FetchChannelMessages;

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
    // [HasPermission(Permission.CanCreateChannel)]
    public async Task<IActionResult> CreateChannel(ChannelWriteModel channelWriteModel)
    {
        var username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

        var addChannelCommand = new CreateChannelCommand(
            channelWriteModel.Name,
            channelWriteModel.Description,
            channelWriteModel.Image,
            channelWriteModel.HubId,
            username);

        ErrorOr<ChannelReadModel> result = await _sender.Send(addChannelCommand);
        return result.Match(
             channel => Ok(channel),
             errors => Problem(errors)
         );

    }


    [HttpGet]
    // [HasPermission(Permission.CanViewChannels)]

    public async Task<IActionResult> ViewChannels([FromQuery] int pageNumber, [FromQuery] int pageSize)
    {
        var query = new ViewChannelsQuery(pageNumber, pageSize);
        var hubs = await _sender.Send(query);

        return Ok(hubs);
    }
    [HttpGet]
    // [Authorize]
    public async Task<IActionResult> ViewChannel([FromQuery] ViewChannelQuery viewChannelQuery)
    {

        var result = await _sender.Send(viewChannelQuery);
        return result.Match(
            channel => Ok(channel),
            errors => Problem(errors)
        );
    }

    [HttpDelete]
    // [HasPermission(Permission.CanDeleteChannel)]

    public async Task<IActionResult> DeleteChannel([FromQuery] Guid id)
    {

        var DeleteModel = new DeletePostCommand(id);
        await _sender.Send(DeleteModel);

        return NoContent();
    }


    [HttpPut]
    public async Task<IActionResult> EditChannel(UpdateChannelCommand channelWriteModel)
    {
        var UpdateChannelCommand = new UpdateChannelCommand(channelWriteModel.ChannelId, channelWriteModel.Name, channelWriteModel.Description);


        var result = await _sender.Send(UpdateChannelCommand);

        return result.Match(
             channel => Ok(channel),
             errors => Problem(errors)
         );
    }
    [HttpGet]
    public async Task<IActionResult> ViewRecentActivities(
        [FromQuery] ViewChannelRecentActivitiesQuery viewChannelRecentActivitiesQuery)
    {
        var result = await _sender.Send(viewChannelRecentActivitiesQuery);
        return Ok(result);
    }


    [HttpGet]
    public async Task<IActionResult> GetChannelMembers([FromQuery] Guid ChannelId)
    {
        var GetChannelMembersQuery = new GetChannelMembersQuery(ChannelId);
        var result = await _sender.Send(GetChannelMembersQuery);
        return result.Match(
             channel => Ok(channel),
             errors => Problem(errors)
         );
    }
    [HttpGet]
    public async Task<IActionResult> FetchChannelMessages([FromQuery] Guid ChannelId)
    {
        var FetchChannelMessagesCommand = new FetchChannelMessagesQuery(ChannelId);
        var result = await _sender.Send(FetchChannelMessagesCommand);
        return result.Match(
             channel => Ok(channel),
             errors => Problem(errors)
         );
    }
}
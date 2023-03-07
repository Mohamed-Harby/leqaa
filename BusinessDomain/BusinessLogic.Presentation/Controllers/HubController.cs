using System.Security.Claims;
using BusinessLogic.Application.Commands.Channels.DeleteChannel;
using BusinessLogic.Application.Commands.Hubs.DeleteHub;
using BusinessLogic.Application.Commands.Hubs.DeployHub;
using BusinessLogic.Application.Commands.Hubs.UpdateHub;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Application.Queries.channels.ViewChannels;
using BusinessLogic.Application.Queries.Hubs.GetAllHubs;
using BusinessLogic.Application.Queries.Hubs.viewHubChannels;
using BusinessLogic.Application.Queries.Hubs.viewHubUsers;
using BusinessLogic.Domain;
using BusinessLogic.Infrastructure.Authorization;
using BusinessLogic.Infrastructure.Authorization.Enums;
using ErrorOr;
using Mapster;
using MediatR; 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BusinessLogic.Presentation.Controllers;
[ApiController]
[Route("api/v1/[controller]/[action]")]

public class HubController : BaseController
{
    private readonly ISender _sender;
    private readonly ILogger<HubController> _logger;

    public HubController(ISender sender, ILogger<HubController> logger)
    {
        _sender = sender;
        _logger = logger;
    }

    [HttpPost]
    [HasPermission(Permission.CanDeployHubs)]
    public async Task<IActionResult> DeployHub(HubWriteModel hub)
    {
        string username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

        var deployHubCommand = new DeployHubCommand(hub.name, hub.description, hub.logo, username);
        ErrorOr<HubReadModel> results = await _sender.Send(deployHubCommand);
        return results.Match(
            hub => Ok(hub),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    // [HasPermission(Permission.CanViewHubs)]

    public async Task<IActionResult> ViewHubs([FromQuery] int pageNumber, int pageSize)
    {
        var query = new GetAllPostsQuery(pageNumber, pageSize);
        var hubs = await _sender.Send(query);

        return Ok(hubs);
    }


    [HttpDelete("{id}")]
    // [HasPermission(Permission.CanDeleteHub)]
    public async Task<IActionResult> DeleteHub(Guid id)
    {

        var DeleteModel = new DeleteHubCommand(id);
        var result = await _sender.Send(DeleteModel);

        return NoContent();
    }



    [HttpPut("")]
    public async Task<IActionResult> EditHub([FromQuery] Guid id, HubUpdateModel hubReadModel)
    {
        var UpdateHubCommand = new UpdateHubCommand(id, hubReadModel.name, hubReadModel.description);


        ErrorOr<HubUpdateModel> results = await _sender.Send(UpdateHubCommand);

        return results.Match(
             hub => Ok(hub),
             errors => Problem(errors)
         );
    }


    [HttpGet]
    public async Task<IActionResult> ViewHubChannels(Guid hubid)
    {
        var channels = new ViewHubChannelsQuery(hubid);
        var result= await _sender.Send(channels);
        return result.Match(
            channels => Ok(channels),
            errors => Problem(errors)
            );
    }


    [HttpGet]
    public async Task<IActionResult> ViewHubUsers(Guid hubid)
    {
        var users = new GetHubsWithoutUserHubsQuery(hubid);
        var result = await _sender.Send(users);
        return result.Match(
            users => Ok(users), 
            errors => Problem(errors)
            );
    }
}



















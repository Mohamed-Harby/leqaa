using System.Security.Claims;
using BusinessLogic.Application.Commands.Hubs.DeleteHub;
using BusinessLogic.Application.Commands.Hubs.DeployHub;
using BusinessLogic.Application.Commands.Hubs.UpdateHub;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Application.Queries.Hubs.GetAllHubs;
using BusinessLogic.Application.Queries.Hubs.ViewHub;
using BusinessLogic.Infrastructure.Authorization;
using BusinessLogic.Infrastructure.Authorization.Enums;
using ErrorOr;
using MediatR;
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
    // [HasPermission(Permission.CanDeployHubs)]
    public async Task<IActionResult> DeployHub(HubWriteModel hub)
    {
        string username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

        var deployHubCommand = new DeployHubCommand(hub.Name, hub.Description, hub.IsPrivate, hub.Logo, username);
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
        var query = new GetAllHubsQuery(pageNumber, pageSize);
        var hubs = await _sender.Send(query);

        return Ok(hubs);
    }
    [HttpGet]
    public async Task<IActionResult> ViewHub([FromQuery] ViewHubQuery viewHubQuery)
    {
        var result = await _sender.Send(viewHubQuery);
        return result.Match(
            hub => Ok(hub),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id}")]
    // [HasPermission(Permission.CanDeleteHub)]
    public async Task<IActionResult> DeleteHub(Guid id)
    {

        var DeleteModel = new DeleteHubCommand(id);
        var result = await _sender.Send(DeleteModel);

        return NoContent();
    }



    [HttpPut]
    public async Task<IActionResult> EditHub([FromQuery] Guid id, HubUpdateModel hubReadModel)
    {
        var UpdateHubCommand = new UpdateHubCommand(id, hubReadModel.name, hubReadModel.description);


        ErrorOr<HubUpdateModel> results = await _sender.Send(UpdateHubCommand);

        return results.Match(
             hub => Ok(hub),
             errors => Problem(errors)
         );
    }
}



















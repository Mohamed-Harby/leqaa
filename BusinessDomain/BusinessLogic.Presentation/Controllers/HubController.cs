using BusinessLogic.Application.Commands.Hubs.AddHub;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Application.Queries.Hubs.GetAllHubs;
using BusinessLogic.Domain;
using ErrorOr;
using Mapster;
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
    public async Task<IActionResult> Post(HubWriteModel hub, string username)
    {
        var addHubCommand = new AddHubCommand(hub.name, hub.description, hub.logo, username);
        ErrorOr<Hub> results = await _sender.Send(addHubCommand);
        return results.Match(
            hub1 => Ok(hub),
            errors => Problem(errors)
        );
    }
    [HttpGet]
    public async Task<ActionResult<IQueryable<Hub>>> GetAll()
    {
        var getAllHubsQuery = new GetAllChannelsQuery();
        var result = await _sender.Send(getAllHubsQuery);

        return Ok(result);
    }
}
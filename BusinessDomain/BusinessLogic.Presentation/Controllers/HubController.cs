using System.Security.Claims;
using BusinessLogic.Application.Commands.Hubs.DeployHub;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Application.Queries.Hubs.GetAllHubs;
using BusinessLogic.Domain;
using BusinessLogic.Infrastructure.Authorization;
using BusinessLogic.Infrastructure.Authorization.Enums;
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
    [HasPermission(Permission.CanDeployHubs)]
    public async Task<IActionResult> Post(HubWriteModel hub)
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
    public async Task<ActionResult<IQueryable<Hub>>> GetAll()
    {
        var getAllHubsQuery = new GetAllHubsQuery();
        var result = await _sender.Send(getAllHubsQuery);

        return Ok(result);


    }
}



















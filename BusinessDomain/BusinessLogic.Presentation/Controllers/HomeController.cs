using BusinessLogic.Application.Queries.Home.ViewRecentActivities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogic.Presentation.Controllers;
[ApiController]
[Route("[controller]/[action]")]
public class HomeController : BaseController
{
    private readonly ISender _sender;
    public HomeController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> ViewRecentActivities([FromQuery] ViewRecentActivitiesQuery viewRecentActivitiesQuery)
    {
        var result = await _sender.Send(viewRecentActivitiesQuery);
        return Ok(result);
    }
}
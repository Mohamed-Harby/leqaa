using BusinessLogic.Application.Queries.MultiQueries.ViewRecentActivities;
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
        return Ok(await _sender.Send(viewRecentActivitiesQuery));//! check why this only returns BaseEntity properties 
                                                                 //! and loses the properties of it's children 
    }
}
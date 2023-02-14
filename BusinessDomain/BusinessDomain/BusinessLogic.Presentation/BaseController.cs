using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogic.Presentation;
[ApiController]
[Route("[controller]/[action]")]
public abstract class BaseController : ControllerBase
{
    [HttpGet]
    public IActionResult Problem(List<Error> errors)
    {
        return BadRequest(errors);
    }
}
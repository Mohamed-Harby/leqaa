using Microsoft.AspNetCore.Mvc;
using MediatR;
using BusinessLogic.Application.Commands.Users.BuyPlan;
using BusinessLogic.Application.Commands.Users.SetProfilePicture;

namespace BusinessLogic.Presentation.Controllers;
[Route("api/v1/[controller]/[action]")]
[ApiController]

public class UserController : BaseController
{
    private readonly ISender _sender;

    public UserController(ISender sender)
    {
        _sender = sender;
    }
    [HttpPost]
    public async Task<IActionResult> BuyPlan(BuyPlanCommand buyPlanCommand)
    {
        var result = await _sender.Send(buyPlanCommand);
        return result.Match(
            plan => Ok(plan),
            errors => Problem(errors)
        );
    }
    [HttpPut]
    public async Task<IActionResult> SetProfilePicture(SetProfilePictureCommand setProfilePictureCommand)
    {
        var result = await _sender.Send(setProfilePictureCommand);
        return result.Match(
            user => Ok(user),
            errors => Problem(errors)
        );
    }
}
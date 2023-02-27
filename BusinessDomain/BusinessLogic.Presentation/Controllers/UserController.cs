using Microsoft.AspNetCore.Mvc;
using MediatR;
using BusinessLogic.Application.Commands.Users.BuyPlan;
using BusinessLogic.Application.Commands.Users.SetProfilePicture;
using BusinessLogic.Application.Models.Plans;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using BusinessLogic.Application.Queries.Users.ViewUserProfile;
using BusinessLogic.Application.Models.Users;

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
    [Authorize]
    public async Task<IActionResult> BuyPlan(PlanWriteModel planWriteModel)
    {
        var username = User.FindFirst(u => u.Type == ClaimTypes.NameIdentifier)!.Value;
        var buyPlanCommand = new BuyPlanCommand(planWriteModel.planType, username);
        var result = await _sender.Send(buyPlanCommand);
        return result.Match(
            plan => Ok(plan),
            errors => Problem(errors)
        );
    }
    [HttpPut]
    [Authorize]
    public async Task<IActionResult> SetProfilePicture([FromBody] ProfilePictureWriteModel profilePictureWriteModel)
    {
        var username = User.FindFirst(u => u.Type == ClaimTypes.NameIdentifier)!.Value;
        var setProfilePictureCommand = new SetProfilePictureCommand(profilePictureWriteModel.ProfilePicture, username);
        var result = await _sender.Send(setProfilePictureCommand);
        return result.Match(
            user => Ok(user),
            errors => Problem(errors)
        );
    }
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> ViewUserProfile()
    {
        var username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var viewUserProfileQuery = new ViewUserProfileQuery(username);
        var result = await _sender.Send(viewUserProfileQuery);
        return result.Match(
            user => Ok(user),
            errors => Problem(errors)
        );
    }
}
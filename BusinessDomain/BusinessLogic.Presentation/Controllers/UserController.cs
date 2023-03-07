using Microsoft.AspNetCore.Mvc;
using MediatR;
using BusinessLogic.Application.Commands.Users.BuyPlan;
using BusinessLogic.Application.Commands.Users.SetProfilePicture;
using BusinessLogic.Application.Models.Plans;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using BusinessLogic.Application.Queries.Users.ViewUserProfile;
using BusinessLogic.Application.Models.Users;
using BusinessLogic.Application.Queries.channels.ViewChannels;
using BusinessLogic.Infrastructure.Authorization;
using BusinessLogic.Application.Queries.Users.ViewUserChannels;
using Microsoft.AspNetCore.Identity;
using System.Runtime.InteropServices;
using BusinessLogic.Application.Queries.Users.ViewUserHubs;
using BusinessLogic.Application.Queries.Users.ViewUserPosts;
using BusinessLogic.Application.Commands.Users.FollowUser;
using ErrorOr;
using BusinessLogic.Application.Queries.Users.ViewRelatedUsers;
using BusinessLogic.Application.Queries.Users.ViewUser;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Application.Commands.Users.JoinHub;
using BusinessLogic.Infrastructure.Authorization.Enums;

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

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> ViewUserChannels()
    {
        string username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

        if (string.IsNullOrEmpty(username))

        {
            return BadRequest(username);
        }

        var ViewUserChannelsQuery = new ViewUserChannelsQuery(username);

        var result = await _sender.Send(ViewUserChannelsQuery);
        return result.Match(
             channels => Ok(channels),
             errors => Problem(errors)
         );

    }


    [HttpGet]
    [Authorize]
    public async Task<IActionResult> ViewUserHubs()
    {
        string username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

        if (string.IsNullOrEmpty(username))
        {
            return BadRequest(username);
        }

        var ViewUserHubsQuery = new ViewUserHubsQuery(username);

        var result = await _sender.Send(ViewUserHubsQuery);
        return result.Match(
             Hubs => Ok(Hubs),
             errors => Problem(errors)
         );

    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> ViewUserPosts()
    {
        string username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

        if (string.IsNullOrEmpty(username))
        {
            return BadRequest(username);
        }

        var ViewUserPostsQuery = new ViewUserPostsQuery(username);

        var result = await _sender.Send(ViewUserPostsQuery);
        return result.Match(
             posts => Ok(posts),
             errors => Problem(errors)
         );
    }
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> FollowUser(FollowUserModel followUserModel)
    {
        var followerUsername = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

        var followUserCommand = new FollowUserCommand(
            FollowedUser: followUserModel.FollowedUserName,
            Follower: followerUsername);

        ErrorOr<UserReadModel> result = await _sender.Send(followUserCommand);
        return result.Match(
            user => Ok(user),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> ViewUsers(int pageNumber = 1, int pageSize = 20)
    {
        string username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var viewRelatedUserQuery = new ViewRelatedUsersQuery(pageNumber, pageSize, username);
        var result = await _sender.Send(viewRelatedUserQuery);
        return result.Match(
            users => Ok(users),
            errors => Problem(errors)
        );
    }
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> ViewUser([FromQuery] ViewUserQuery viewUserQuery)
    {
        var result = await _sender.Send(viewUserQuery);
        return result.Match(
            users => Ok(users),
            errors => Problem(errors)
        );
    }
    [HttpPut]
    [HasPermission(Permission.CanJoinHub)]
    public async Task<IActionResult> JoinHub(JoinHubModel joinHubModel)
    {
        string username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

        var joinHubCommand = new JoinHubCommand(username, joinHubModel.Id);
        var result = await _sender.Send(joinHubCommand);
        return result.Match(
            hub => Ok(hub),
            errors => Problem(errors)
        );

    }

}
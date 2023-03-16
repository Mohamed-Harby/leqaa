using Microsoft.AspNetCore.Mvc;
using MediatR;
using BusinessLogic.Application.Commands.Users.BuyPlan;
using BusinessLogic.Application.Commands.Users.SetProfilePicture;
using BusinessLogic.Application.Models.Plans;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using BusinessLogic.Application.Queries.Users.ViewUserProfile;
using BusinessLogic.Application.Models.Users;
using BusinessLogic.Infrastructure.Authorization;
using BusinessLogic.Application.Queries.Users.ViewUserChannels;
using BusinessLogic.Application.Queries.Users.ViewUserHubs;
using BusinessLogic.Application.Queries.Users.ViewUserPosts;
using BusinessLogic.Application.Commands.Users.FollowUser;
using ErrorOr;
using BusinessLogic.Application.Queries.Users.ViewRelatedUsers;
using BusinessLogic.Application.Queries.Users.ViewUser;
using BusinessLogic.Application.Queries.Hubs.GetHubsWithoutUserHubs;
using BusinessLogic.Application.Commands.Users.JoinHub;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Infrastructure.Authorization.Enums;
using BusinessLogic.Application.Commands.Users.AddUserByUser;
using BusinessLogic.Application.Commands.Users.UpdateUserRole;
using BusinessLogic.Domain.SharedEnums;
using BusinessLogic.Application.Queries.Users.ViewRecentActivities;

using BusinessLogic.Application.Commands.Users.LeaveHub;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Commands.Users.LeaveChannel;

using BusinessLogic.Application.Commands.Pin.PinChannels;
using BusinessLogic.Application.Commands.Users.JoinChannel;
using BusinessLogic.Application.Commands.Pin.PinHubs;
using BusinessLogic.Application.Models.Posts;
using BusinessLogic.Application.Commands.Pin.PinPosts;


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
            UserName: followerUsername);

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

    [HttpDelete]
    public async Task<IActionResult> LeaveHub(LeaveHubModel leaveHubModel)
    {
        string username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

        var LeaveHubCommand = new LeaveHubCommand(username, leaveHubModel.Id);
        var result = await _sender.Send(LeaveHubCommand);
        return result.Match(
            hub => Ok(hub),
            errors => Problem(errors)
        );

    }



    [HttpDelete]
    public async Task<IActionResult> LeavChannel(LeaveChannelModel LeaveChannelModel)
    {
        string username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

        var LeaveChannelCommand = new LeaveChannelCommand(username, LeaveChannelModel.Id);
        var result = await _sender.Send(LeaveChannelCommand);
        return result.Match(
            channel=> Ok(channel),
            errors => Problem(errors)
        );

    }



    [HttpGet]
    public async Task<IActionResult> GetHubsWithoutUserHubs()
    {
        string username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var model = new GetHubsWithoutUserHubsQuery(username);
        var result = await _sender.Send(model);
        return result.Match(
            users => Ok(users),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddUserByUserToHub(AddUserByUserCommand addUserByUserCommand)
    {

        var result = await _sender.Send(addUserByUserCommand);
        return result.Match(
            users => Ok(users),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> UpdateUserRole(string UsertoUpdate, GroupRole newRole)
    {
        string usernameWhoUpdate = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var updateUserRoleCommand = new UpdateUserRoleCommand(usernameWhoUpdate, UsertoUpdate, newRole);

        var result = await _sender.Send(updateUserRoleCommand);

        return result.Match(
            users => Ok(users),
            errors => Problem(errors)
        );
    }
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> ViewRecentActivities(int pageNumber = 1, int pageSize = 20)
    {
        string username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var viewRecentActivitiesQuery = new ViewUserRecentActivitiesQuery(pageNumber, pageSize, username);

        var result = await _sender.Send(viewRecentActivitiesQuery);
        return result.Match(
            user => Ok(user),
            errors => Problem(errors)
        );
    }
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> JoinChannel(JoinChannelModel joinChannelModel)
    {
        string username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var joinChannelCommand = new JoinChannelCommand(username, joinChannelModel.Id);
        var result = await _sender.Send(joinChannelCommand);
        return result.Match(
            channel => Ok(channel),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> PinChannel(PinChannelModel pinChannelModel)
    {
        string username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var pinChannelCommand = new PinChannelCommand(username, pinChannelModel.Id);
        var result = await _sender.Send(pinChannelCommand);
        return result.Match(
            channel => Ok(channel),
            errors => Problem(errors));
    }
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> PinHub(PinHubModel pinHubModel)
    {
        string username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var pinHubCommand = new PinHubCommand(username, pinHubModel.Id);
        var result = await _sender.Send(pinHubCommand);
        return result.Match(
            hub => Ok(hub),
            errors => Problem(errors));
    }
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> PinPost(PinPostModel pinPostModel)
    {
        string username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var pinPostCommand = new PinPostCommand(username, pinPostModel.Id);
        var result = await _sender.Send(pinPostCommand);
        return result.Match(
            post => Ok(post),
            errors => Problem(errors));
    }
}
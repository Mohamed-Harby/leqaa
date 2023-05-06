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
using BusinessLogic.Application.Commands.Pin.ViewPinned.ViewpinnedHubs;
using BusinessLogic.Application.Commands.Users.JoinChannel;
using BusinessLogic.Application.Commands.Pin.PinHubs;
using BusinessLogic.Application.Models.Posts;
using BusinessLogic.Application.Commands.Pin.PinPosts;
using BusinessLogic.Application.Commands.Pin.ViewPinned.ViewpinnedChannels;
using BusinessLogic.Application.Commands.Pin.ViewPinned.ViewpinnedPosts;
using BusinessLogic.Application.Commands.Pin.DeletePin.DeletePinnedChannel;
using BusinessLogic.Application.Commands.Pin.DeletePin.DeletePinnedHub;
using BusinessLogic.Application.Commands.Pin.DeletePin.DeletePinnedPost;
using BusinessLogic.Application.Queries.Users.GetFollowedUsersCount;
using BusinessLogic.Application.Queries.Users.GetFollowerUsersCount;
using BusinessLogic.Application.Queries.Users.ViewFollowers;
using BusinessLogic.Application.Queries.Users.ViewFollowed;
using BusinessLogic.Application.Commands.Users.AddMultibleUsersByUser;
using BusinessLogic.Application.Queries.Users.GetChannelUserNotIn;

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
    public async Task<IActionResult> LeaveHub([FromQuery] Guid hubID)
    {
        string username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

        var LeaveHubCommand = new LeaveHubCommand(username, hubID);
        var result = await _sender.Send(LeaveHubCommand);
        return Ok(result);

    }
    


    [HttpDelete]
    public async Task<IActionResult> LeavChannel([FromQuery] Guid ChannelID)
    {
        string username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

        var LeaveChannelCommand = new LeaveChannelCommand(username, ChannelID);
        var result = await _sender.Send(LeaveChannelCommand);
        return result.Match(
            channel => Ok(channel),
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


    //pin work
    [HttpGet]

    public async Task<IActionResult> ViewUserPinnedHubs()
    {
        var username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var ViewPinnedHubsCommand = new ViewPinnedHubsCommand(username);
        var results = await _sender.Send(ViewPinnedHubsCommand);
        return results.Match(
               hubs => Ok(hubs),
               errors => Problem(errors));
    }
    [HttpGet]

    public async Task<IActionResult> ViewUserPinnedChannels()
    {
        var username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var ViewPinnedHubsCommand = new ViewPinnedChannelsCommand(username);
        var results = await _sender.Send(ViewPinnedHubsCommand);
        return results.Match(
               channels => Ok(channels),
               errors => Problem(errors));
    }

    [HttpGet]

    public async Task<IActionResult> ViewUserPinnedPosts()
    {
        var username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var ViewPinnedHubsCommand = new ViewPinnedPostsCommand(username);
        var results = await _sender.Send(ViewPinnedHubsCommand);
        return results.Match(
               posts => Ok(posts),
               errors => Problem(errors));
    }



    [HttpDelete]

    public async Task<IActionResult> DeleteUserPinnedChannels([FromQuery] Guid ChannelId)
    {
        var username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var DeleteUserPinnedChannel = new DeletePinnedChannelCommand(username, ChannelId);
        var results = await _sender.Send(DeleteUserPinnedChannel);
        return results.Match(
               delete => Ok(delete),
               errors => Problem(errors));
    }

    [HttpDelete]

    public async Task<IActionResult> DeleteUserPinnedHub([FromQuery] Guid HubId)
    {
        var username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var DeleteUserPinnedHub = new DeletePinnedHubCommand(username, HubId);
        var results = await _sender.Send(DeleteUserPinnedHub);
        return results.Match(
               delete => Ok(delete),
               errors => Problem(errors));
    }
    [HttpDelete]

    public async Task<IActionResult> DeleteUserPinnedPost([FromQuery] Guid PostId)
    {
        var username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var DeleteUserPinnedpost = new DeletePinnedPostCommand(username, PostId);
        var results = await _sender.Send(DeleteUserPinnedpost);
        return results.Match(
               delete => Ok(delete),
               errors => Problem(errors));
    }


    //Get Followed users
    [HttpGet]
    public async Task<IActionResult> GetFollowedUsersCount([FromQuery] Guid UserId)
    {
        var GetFollowedUsersCountQuery = new GetFollowedUsersCountQuery(UserId);
        var results = await _sender.Send(GetFollowedUsersCountQuery);
        return results.Match(
               results => Ok(results),
               errors => Problem(errors));

    }
    //Get Followers
    [HttpGet]
    public async Task<IActionResult> GetFollowerUsersCount([FromQuery] Guid UserId)
    {
        var GetFollowerUsersCountQuery = new GetFollowerUsersCountQuery(UserId);
        var results = await _sender.Send(GetFollowerUsersCountQuery);
        return results.Match(
               results => Ok(results),
               errors => Problem(errors));

    }

    //view followers
    [HttpGet]
    public async Task<IActionResult> ViewFollowers([FromQuery] Guid UserId)
    {
        var ViewFollowersQuery = new ViewFollowersQuery(UserId);
        var result = await _sender.Send(ViewFollowersQuery);
        return result.Match(
             results => Ok(results),
             errors => Problem(errors));

    }

    //view followers
    [HttpGet]
    public async Task<IActionResult> ViewFollowed([FromQuery] Guid UserId)
    {
        var ViewFollowedQuery = new ViewFollowedQuery(UserId);
        var result = await _sender.Send(ViewFollowedQuery);
        return result.Match(
             results => Ok(results),
             errors => Problem(errors));

    }
    [HttpPost]
    public async Task<IActionResult> AddUsersByUser([FromBody] AddMultibleUsersByUserCommand request)
    {
        var command = new AddMultibleUsersByUserCommand
        (
           request.UserName,
            request.AddedUserNames,
             request.HubId
        );

        var result = await _sender.Send(command);

        return result.Match(
            addedUsers => Ok(addedUsers),
            errors => Problem(errors)
        );
    }
    [HttpGet("available")]
    public async Task<IActionResult> GetAvailableChannels()
    {

        var username = User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

        var query = new GetChannelUserNotInQuery(username);
        var result = await _sender.Send(query);

        return result.Match(
           addedUsers => Ok(addedUsers),
           errors => Problem(errors)
       );
    }

}
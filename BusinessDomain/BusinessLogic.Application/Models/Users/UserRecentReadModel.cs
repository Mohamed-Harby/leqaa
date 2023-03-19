using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Application.Models.Plans;
using BusinessLogic.Application.Models.Posts;

namespace BusinessLogic.Application.Models.Users;

public record UserRecentReadModel(
    Guid Id,
    string Name,
    string Email,
    string UserName,
    bool IsFollowed,
    byte[]? ProfilePicture,
    List<PlanReadModel> Plans,
    List<HubReadModel> Hubs,
    List<ChannelReadModel> Channels,
    List<PostReadModel> Posts,
    List<UserReadModel> Followers,
    List<UserReadModel> FollowedUsers,
    DateTime CreationDate
    ) : BaseReadModel(Id, CreationDate);


using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Application.Models.Plans;


namespace BusinessLogic.Application.Models.Users;

public record UserReadModel(
    Guid Id,
    string Name,
    string Email,
    string UserName,
    bool IsFollowed,
    byte[]? ProfilePicture,
    List<PlanReadModel> Plans,
    List<HubReadModel> Hubs,
    List<ChannelReadModel> Channels
    );


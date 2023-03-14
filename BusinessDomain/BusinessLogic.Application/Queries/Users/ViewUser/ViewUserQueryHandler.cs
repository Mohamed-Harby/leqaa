using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Users;
using ErrorOr;
using Mapster;

namespace BusinessLogic.Application.Queries.Users.ViewUser;
public class ViewUserQueryHandler : IHandler<ViewUserQuery, ErrorOr<UserRecentReadModel>>
{
    private readonly IUserRepository _userRepository;

    public ViewUserQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<UserRecentReadModel>> Handle(ViewUserQuery request, CancellationToken cancellationToken)
    {
        var user = (await _userRepository.GetAsync(u => u.UserName == request.UserName, null!, "Plans,Posts,Hubs,Channels,HubAnnouncements,ChannelAnnouncements")).FirstOrDefault()!;
        return user.Adapt<UserRecentReadModel>();
    }
}

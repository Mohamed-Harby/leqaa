using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Users;
using BusinessLogic.Domain.Common.Errors;
using ErrorOr;
using Mapster;

namespace BusinessLogic.Application.Queries.Users.ViewUserProfile;
public class ViewUserProfileQueryHandler : IHandler<ViewUserProfileQuery, ErrorOr<UserRecentReadModel>>
{
    private readonly IUserRepository _userRepository;

    public ViewUserProfileQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<UserRecentReadModel>> Handle(ViewUserProfileQuery request, CancellationToken cancellationToken)
    {
        var user = (await _userRepository.GetAsync(u => u.UserName == request.UserName, null!, "Hubs,Plans,Channels")).FirstOrDefault();
        var userReadModel = user!.Adapt<UserRecentReadModel>();
        return userReadModel;
    }
}

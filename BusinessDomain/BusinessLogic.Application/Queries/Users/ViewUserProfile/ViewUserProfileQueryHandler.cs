using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Users;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using Mapster;

namespace BusinessLogic.Application.Queries.Users.ViewUserProfile;
public class ViewUserProfileQueryHandler : IHandler<ViewUserProfileQuery, ErrorOr<UserReadModel>>
{
    private readonly IUserRepository _userRepository;

    public ViewUserProfileQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<UserReadModel>> Handle(ViewUserProfileQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserWithPlansWithHubsAsync(request.UserName);
        if (user is null)
        {
            return DomainErrors.User.NotFound;
        }
        var userReadModel = user.Adapt<UserReadModel>();
        return userReadModel;
    }
}

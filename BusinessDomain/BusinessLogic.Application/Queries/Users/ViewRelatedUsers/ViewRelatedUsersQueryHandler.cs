using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Users;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using Mapster;

namespace BusinessLogic.Application.Queries.Users.ViewRelatedUsers;
public class ViewRelatedUsersQueryHandler : IHandler<ViewRelatedUsersQuery, ErrorOr<List<UserReadModel>>>
{
    private readonly IUserRepository _userRepository;

    public ViewRelatedUsersQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<List<UserReadModel>>> Handle(ViewRelatedUsersQuery request, CancellationToken cancellationToken)
    {
        var users = (await _userRepository.GetAllAsync())
        .Take(request.PageSize)
        .Skip((request.PageNumber - 1) * request.PageSize).ToList();

        var user = (await _userRepository.GetAsync(u => u.UserName == request.UserName, null!, "FollowedUsers")).FirstOrDefault();
        if (user is null)
        {
            return DomainErrors.User.NotFound;
        }
        for (int i = 0; i < users.Count; i++)
        {
            if (user.FollowedUsers.Contains(users[i]))
            {
                users[i].IsFollowed = true;
            }
        }
        return users.Adapt<List<UserReadModel>>();
    }
}

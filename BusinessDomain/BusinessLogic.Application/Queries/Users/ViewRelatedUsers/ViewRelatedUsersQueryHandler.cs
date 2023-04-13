using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Users;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using Mapster;

namespace BusinessLogic.Application.Queries.Users.ViewRelatedUsers;
public class ViewRelatedUsersQueryHandler : IHandler<ViewRelatedUsersQuery, ErrorOr<List<UserRecentReadModel>>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserUserRepository _userUserRepository;
    public ViewRelatedUsersQueryHandler(IUserRepository userRepository, IUserUserRepository userUserRepository)
    {
        _userRepository = userRepository;
        _userUserRepository = userUserRepository;
    }

    public async Task<ErrorOr<List<UserRecentReadModel>>> Handle(ViewRelatedUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync();
        users.Take(request.PageSize)
        .Skip((request.PageNumber - 1) * request.PageSize).ToList();

        var followedUsers = (await _userRepository.GetAsync(u => u.UserName == request.UserName, null, "FollowedUsers"))
        .FirstOrDefault()!
        .FollowedUsers;
        users = users.Select(x => new Domain.User
        {
            Id = x.Id,
            UserName = x.UserName,
            Email = x.Email,
            ProfilePicture = x.ProfilePicture,
            Gender = x.Gender,
            Name = x.Name,
            IsFollowed = followedUsers.Contains(x),
        });

        return users.Adapt<List<UserRecentReadModel>>();
    }
}

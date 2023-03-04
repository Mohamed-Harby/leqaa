using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Users;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using Mapster;

namespace BusinessLogic.Application.Commands.Users.FollowUser;
public class FollowUserCommandHandler : IHandler<FollowUserCommand, ErrorOr<UserReadModel>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserUserRepository _userUserRepository;

    public FollowUserCommandHandler(IUserRepository userRepository, IUserUserRepository userUserRepository)
    {
        _userRepository = userRepository;
        _userUserRepository = userUserRepository;
    }

    public async Task<ErrorOr<UserReadModel>> Handle(FollowUserCommand request, CancellationToken cancellationToken)
    {
        var followedUser = (await _userRepository.GetAsync(u => u.UserName == request.FollowedUser)).FirstOrDefault();
        var follower = (await _userRepository.GetAsync(u => u.UserName == request.Follower)).FirstOrDefault();
        if ((follower is null) || (followedUser is null))
        {
            return DomainErrors.User.NotFound;
        }
        var followRelation = (await _userUserRepository
        .GetAsync(uu =>
         uu.FollowerId == follower.Id &&
         uu.FollowedId == followedUser.Id))
        .FirstOrDefault();
        if (followRelation is not null)
        {
            return DomainErrors.UserUser.AlreadyFollowed;
        }
        follower.FollowedUsers.Add(followedUser);
        if (await _userRepository.SaveAsync(cancellationToken) == 0)
        {
            return DomainErrors.User.InvalidFollowedUser;
        }
        return followedUser.Adapt<UserReadModel>();
    }
}

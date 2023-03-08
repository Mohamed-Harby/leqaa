using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Users;
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
        var follower = (await _userRepository.GetAsync(u => u.UserName == request.UserName)).FirstOrDefault()!;

        if ((followedUser is null))
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
            await _userUserRepository.RemoveAsync(uu =>
                uu.FollowerId == follower.Id &&
                uu.FollowedId == followedUser.Id);
            if (await _userRepository.SaveAsync(cancellationToken) == 0)
            {
                return DomainErrors.User.InvalidFollowedUser;
            }
            return followedUser.Adapt<UserReadModel>();
        }

        follower.FollowedUsers.Add(followedUser);

        if (await _userRepository.SaveAsync(cancellationToken) == 0)
        {
            return DomainErrors.User.InvalidFollowedUser;
        }
        return followedUser.Adapt<UserReadModel>();
    }
}

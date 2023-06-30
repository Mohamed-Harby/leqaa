using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Users;
using BusinessLogic.Domain.Common.Errors;
using ErrorOr;
using Mapster;

using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Users;
using BusinessLogic.Domain.Common.Errors;
using ErrorOr;
using Mapster;

namespace BusinessLogic.Application.Commands.Users.FollowUser
{
    public class FollowUserCommandHandler : IHandler<FollowUserCommand, ErrorOr<UserReadModel>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserUserRepository _userUserRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FollowUserCommandHandler(IUserRepository userRepository, IUserUserRepository userUserRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _userUserRepository = userUserRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<UserReadModel>> Handle(FollowUserCommand request, CancellationToken cancellationToken)
        {
            var followedUser = (await _userRepository.GetAsync(u => u.UserName == request.FollowedUser)).FirstOrDefault();
            var follower = (await _userRepository.GetAsync(u => u.UserName == request.UserName)).FirstOrDefault()!;


            if (followedUser is null)
            {
                return DomainErrors.User.NotFound;
            }

            var followRelation = (await _userUserRepository.GetAsync(uu =>
                uu.FollowerId == follower.Id && uu.FollowedId == followedUser.Id)).FirstOrDefault();

            if (followRelation is not null)
            {
                return DomainErrors.User.InvalidFollowedUser;
            }

            followedUser.IsFollowed = true;
            follower.FollowedUsers.Add(followedUser);

            await _unitOfWork.SaveAsync(cancellationToken);

            return followedUser.Adapt<UserReadModel>();
        }
    }
}


/*using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Users;
using BusinessLogic.Domain.Common.Errors;
using ErrorOr;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Application.Commands.Users.FollowUser;
public class FollowUserCommandHandler : IHandler<FollowUserCommand, ErrorOr<UserReadModel>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUserUserRepository _userUserRepository;
    private readonly IUnitOfWork _unitOfWork;

    public FollowUserCommandHandler(IUserRepository userRepository, IUserUserRepository userUserRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _userUserRepository = userUserRepository;
        _unitOfWork = unitOfWork;
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
          

        }
        await _unitOfWork.useruser(followedUser, follower);

        await _userRepository.SaveAsync();
        return followedUser.Adapt<UserReadModel>();
    }
}

*/
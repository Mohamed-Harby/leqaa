using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Users;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using Mapster;

namespace BusinessLogic.Application.Commands.Users.SetProfilePicture;
public class SetProfilePictureCommandHandler : IHandler<SetProfilePictureCommand, ErrorOr<UserReadModel>>
{
    private readonly IUserRepository _userRepository;

    public SetProfilePictureCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<UserReadModel>> Handle(SetProfilePictureCommand request, CancellationToken cancellationToken)
    {
        var user = (await _userRepository.GetAsync(u => u.UserName == request.Username)).FirstOrDefault();
        if (user is null)
        {
            return DomainErrors.User.NotFound;
        }
        user.ProfilePicture = request.ProfilePicture;
        await _userRepository.UpdateAsync(user);
        if (await _userRepository.SaveAsync(cancellationToken) == 0)
        {
            return Error.Failure("User.Failure", "Failed to save changes, please check the picture format");
        }
        return user.Adapt<UserReadModel>();

    }
}

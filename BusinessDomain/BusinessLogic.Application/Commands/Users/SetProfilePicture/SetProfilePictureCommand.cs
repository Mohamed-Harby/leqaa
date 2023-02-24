using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Users;
using ErrorOr;

namespace BusinessLogic.Application.Commands.Users.SetProfilePicture;
public record SetProfilePictureCommand(
    byte[] ProfilePicture,
    string Username
) : ICommand<ErrorOr<UserReadModel>>;
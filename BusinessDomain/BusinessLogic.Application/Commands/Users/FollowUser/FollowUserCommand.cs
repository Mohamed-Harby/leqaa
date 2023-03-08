using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Users;
using ErrorOr;

namespace BusinessLogic.Application.Commands.Users.FollowUser;
public record FollowUserCommand(
    string FollowedUser,
    string UserName
) : IUserNameInCommand<ErrorOr<UserReadModel>>;
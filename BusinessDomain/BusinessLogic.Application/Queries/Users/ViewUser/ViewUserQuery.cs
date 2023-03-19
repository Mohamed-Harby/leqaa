using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Users;
using ErrorOr;

namespace BusinessLogic.Application.Queries.Users.ViewUser;
public record ViewUserQuery(
    string UserName
) : IUserNameInQuery<ErrorOr<UserRecentReadModel>>;
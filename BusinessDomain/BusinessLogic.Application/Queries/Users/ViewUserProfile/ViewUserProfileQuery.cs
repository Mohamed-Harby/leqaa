using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Users;
using ErrorOr;

namespace BusinessLogic.Application.Queries.Users.ViewUserProfile;
public record ViewUserProfileQuery(
    string UserName
) : IQuery<ErrorOr<UserReadModel>>;
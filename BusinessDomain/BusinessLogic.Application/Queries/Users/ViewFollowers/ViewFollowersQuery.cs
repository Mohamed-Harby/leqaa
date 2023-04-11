using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Users;
using ErrorOr;

namespace BusinessLogic.Application.Queries.Users.ViewFollowers;
public record ViewFollowersQuery(
    Guid UserId

) :IQuery<ErrorOr<List<UserReadModel>>>;
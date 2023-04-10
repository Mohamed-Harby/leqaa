using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Users;
using ErrorOr;

namespace BusinessLogic.Application.Queries.Users.ViewFollowed;
public record ViewFollowedQuery(
    Guid UserId

) :IQuery<ErrorOr<List<UserReadModel>>>;
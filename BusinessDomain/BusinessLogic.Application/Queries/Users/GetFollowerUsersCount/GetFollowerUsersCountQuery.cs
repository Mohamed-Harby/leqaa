using BusinessLogic.Application.CommandInterfaces;

using BusinessLogic.Application.Models.Users;

using ErrorOr;


namespace BusinessLogic.Application.Queries.Users.GetFollowerUsersCount;

public record GetFollowerUsersCountQuery(
Guid UserId

 ) : IQuery<ErrorOr<int>>;
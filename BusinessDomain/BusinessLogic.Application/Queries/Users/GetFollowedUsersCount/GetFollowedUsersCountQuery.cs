using BusinessLogic.Application.CommandInterfaces;

using BusinessLogic.Application.Models.Users;

using ErrorOr;


namespace BusinessLogic.Application.Queries.Users.GetFollowedUsersCount;

public record GetFollowedUsersCountQuery(
Guid UserId

 ) : IQuery<ErrorOr<int>>;
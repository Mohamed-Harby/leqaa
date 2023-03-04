using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models.Users;
using ErrorOr;

namespace BusinessLogic.Application.Queries.Users.ViewRelatedUsers;
public record ViewRelatedUsersQuery(
    int PageNumber,
    int PageSize,
    string UserName
) : IQuery<ErrorOr<List<UserReadModel>>>;
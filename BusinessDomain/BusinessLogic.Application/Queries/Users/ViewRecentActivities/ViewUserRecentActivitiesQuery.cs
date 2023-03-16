using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models;
using BusinessLogic.Domain;
using ErrorOr;

namespace BusinessLogic.Application.Queries.Users.ViewRecentActivities;
public record ViewUserRecentActivitiesQuery(
    int PageNumber,
    int PageSize,
    string UserName
) : IUserNameInQuery<ErrorOr<List<BaseReadModel>>>;


using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models;
using BusinessLogic.Domain;

namespace BusinessLogic.Application.Queries.Users.ViewRecentActivities;
public record ViewUserRecentActivitiesQuery(
    int PageNumber,
    int PageSize,
    string UserName
) : IUserNameInQuery<List<BaseReadModel>>;


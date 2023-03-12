using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models;

namespace BusinessLogic.Application.Queries.Home.ViewRecentActivities;
public record ViewRecentActivitiesQuery(
    int PageNumber,
    int PageSize) : IQuery<List<BaseReadModel>>;
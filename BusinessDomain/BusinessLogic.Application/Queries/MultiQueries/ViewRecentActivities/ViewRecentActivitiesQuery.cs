using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models;
using BusinessLogic.Domain;

namespace BusinessLogic.Application.Queries.MultiQueries.ViewRecentActivities;
public record ViewRecentActivitiesQuery(
    int PageNumber,
    int PageSize) : IQuery<List<BaseReadModel>>;
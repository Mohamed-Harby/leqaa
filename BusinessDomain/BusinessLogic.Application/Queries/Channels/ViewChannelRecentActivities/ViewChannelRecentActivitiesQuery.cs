using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Models;


namespace BusinessLogic.Application.Queries.Channels.ViewRecentActivities;
public record ViewChannelRecentActivitiesQuery(
    Guid Id,
    int PageNumber,
    int PageSize
) : IQuery<List<BaseReadModel>>;
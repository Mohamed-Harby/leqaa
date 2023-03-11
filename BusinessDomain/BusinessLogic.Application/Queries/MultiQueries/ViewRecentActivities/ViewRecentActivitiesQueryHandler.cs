using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models;
using BusinessLogic.Domain;
using Mapster;

namespace BusinessLogic.Application.Queries.MultiQueries.ViewRecentActivities;
public class ViewRecentActivitiesQueryHandler : IHandler<ViewRecentActivitiesQuery, List<BaseReadModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public ViewRecentActivitiesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<BaseReadModel>> Handle(ViewRecentActivitiesQuery request, CancellationToken cancellationToken)
    {
        var recentActivities = await _unitOfWork.GetRecentActivitiesAsync(request.PageNumber, request.PageSize);
        return recentActivities.Adapt<List<BaseReadModel>>();
    }
}

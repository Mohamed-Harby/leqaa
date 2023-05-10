using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models;
using BusinessLogic.Domain;
using ErrorOr;
using Mapster;

namespace BusinessLogic.Application.Queries.Users.ViewRecentActivities;
public class ViewUserRecentActivitiesQueryHandler : IHandler<ViewUserRecentActivitiesQuery, ErrorOr<List<BaseReadModel>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public ViewUserRecentActivitiesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<List<BaseReadModel>>> Handle(ViewUserRecentActivitiesQuery request, CancellationToken cancellationToken)
    {
        var recentActivities = await _unitOfWork.GetUserRecentActivitiesAsync(
            request.UserName,
            request.PageNumber,
            request.PageSize);
        return recentActivities.Adapt<List<BaseReadModel>>();
    }
}

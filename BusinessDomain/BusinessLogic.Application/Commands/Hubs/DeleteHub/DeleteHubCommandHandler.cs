using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using Mapster;
using MediatR;

namespace BusinessLogic.Application.Commands.Hubs.DeleteHub;
public class DeleteHubCommandHandler : IHandler<DeleteHubCommand, ErrorOr<Hub>>
{
    private readonly IHubRepository _HubRepository;
    private readonly IHubRepository _hubRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteHubCommandHandler(
        IHubRepository HubRepository,
        IHubRepository hubRepository,
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _HubRepository = HubRepository;
        _hubRepository = hubRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Hub>> Handle(DeleteHubCommand request, CancellationToken cancellationToken)
    {
        User creatorUser = (await _userRepository.GetAsync(u => u.UserName == request.Username)).FirstOrDefault()!;
        if (creatorUser is null)
        {
            return DomainErrors.User.NotFound;
        }
        Hub hub = await _hubRepository.GetByIdAsync(request.HubId);
        if (hub is null)
        {
            return DomainErrors.Hub.NotFound;
        }
        var Hub = request.Adapt<Hub>();
        await _HubRepository.DeleteHubWithUserAsync(Hub, creatorUser);
        if (await _unitOfWork.Save() == 0)
        {
            return DomainErrors.Hub.InvalidHub;
        }
        return Hub;
    }
}

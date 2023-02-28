using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using Mapster;
using MediatR;

namespace BusinessLogic.Application.Commands.Hubs.DeleteHub;
public class DeleteHubCommandHandler : IHandler<DeleteHubCommand, ErrorOr<Unit>>
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

    public async Task<ErrorOr<Unit>> Handle(DeleteHubCommand request, CancellationToken cancellationToken)
    {

        var hub = await _HubRepository.GetByIdAsync(request.hubId);
        if (hub is null)
        {
            return DomainErrors.Hub.NotFound;
        }
      
        _hubRepository.Remove(hub);

        if (await _unitOfWork.Save() == 0)
        {
            return DomainErrors.Hub.InvalidHub;
        }
        return Unit.Value;
    }
}

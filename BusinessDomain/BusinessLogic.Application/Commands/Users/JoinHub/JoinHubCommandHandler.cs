using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using Mapster;

namespace BusinessLogic.Application.Commands.Users.JoinHub;
public class JoinHubCommandHandler : IHandler<JoinHubCommand, ErrorOr<HubReadModel>>
{
    private readonly IUserRepository _userRepository;
    private readonly IHubRepository _hubRepository;
    private readonly IUserHubRepository _userHubRepository;
    public JoinHubCommandHandler(
        IUserRepository userRepository,
        IHubRepository hubRepository,
        IUserHubRepository userHubRepository)
    {
        _userRepository = userRepository;
        _hubRepository = hubRepository;
        _userHubRepository = userHubRepository;
    }

    public async Task<ErrorOr<HubReadModel>> Handle(JoinHubCommand request, CancellationToken cancellationToken)
    {
        var user = (await _userRepository.GetAsync(u => u.UserName == request.UserName)).FirstOrDefault()!;
        var hub = await _hubRepository.GetByIdAsync(request.HubId);
        if (hub is null)
        {
            return DomainErrors.Hub.NotFound;
        }
        var userHub = (await _userHubRepository.GetAsync(uh => uh.UserId == user.Id && uh.HubId == hub.Id)).FirstOrDefault();
        if (userHub is not null)
        {
            return DomainErrors.UserHub.AlreadyJoined;
        }
        hub.AddUser(user);
        if (await _hubRepository.SaveAsync(cancellationToken) == 0)
        {
            return DomainErrors.Hub.CannotJoinHub;
        }
        return hub.Adapt<HubReadModel>();

    }
}

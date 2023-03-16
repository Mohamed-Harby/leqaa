using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Hubs;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using BusinessLogic.Domain.SharedEnums;
using BusinessLogic.Shared;
using ErrorOr;
using Mapster;

namespace BusinessLogic.Application.Commands.Hubs.DeployHub;
public class DeployHubCommandHandler : IHandler<DeployHubCommand, ErrorOr<HubReadModel>>
{
    private readonly IHubRepository _hubRepository;
    private readonly IUserRepository _userRepository;
    private readonly IFileManager _fileManager;
    private readonly IUnitOfWork _unitOfWork;
    public DeployHubCommandHandler(
        IHubRepository hubRepository,
        IUserRepository userRepository,
        IFileManager fileManager,
        IUnitOfWork unitOfWork)
    {
        _hubRepository = hubRepository;
        _userRepository = userRepository;
        _fileManager = fileManager;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<HubReadModel>> Handle(DeployHubCommand request, CancellationToken cancellationToken)
    {
        byte[] image = await _fileManager
        .GetByteArrayFromImageAsync(
            Path.Combine(Environment.CurrentDirectory, "../Assets/HubPlaceHolder.png")
            );
        var hub = request.Adapt<Hub>();
        hub.Logo = request.Logo ?? image;

        var creatorUser = (await _userRepository.GetAsync(u => u.UserName == request.UserName)).FirstOrDefault();
        await _unitOfWork.CreateHubAsync(hub, creatorUser!);
        if (await _userRepository.SaveAsync() == 0)
        {
            return DomainErrors.Hub.InvalidHub;
        }

        return hub.Adapt<HubReadModel>();
    }
}

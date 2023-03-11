using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Commands.Annoucements.HubAnnoucements;
using BusinessLogic.Application.Commands.Channels.CreateChannel;
using BusinessLogic.Application.Extensions;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Annoucements.HubAnnoucements;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Queries.Hubs.viewHubUsers;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using BusinessLogic.Domain.SharedEnums;
using ErrorOr;
using FluentValidation;
using Mapster;


namespace BusinessLogic.Application.Commands.Annoucements.HubAnnoucements;
public class DeployHubAnnoucementCommandHandler : IHandler<DeployHubAnnoucementCommand, ErrorOr<HubAnnouncementReadModel>>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IHubAnnouncementRepository _hubAnnouncementRepository;
    private readonly IUserRepository _userRepository;
    private readonly IHubRepository _hubRepository;

    public DeployHubAnnoucementCommandHandler(

        IUnitOfWork unitOfWork, IHubAnnouncementRepository hubAnnouncementRepository, IUserRepository userRepository, IHubRepository hubRepository)
    {

        _unitOfWork = unitOfWork;
        _hubAnnouncementRepository = hubAnnouncementRepository;
        _userRepository = userRepository;
        _hubRepository = hubRepository;
    }

    public async Task<ErrorOr<HubAnnouncementReadModel>> Handle(DeployHubAnnoucementCommand request, CancellationToken cancellationToken)
    {
        User? creatorUser = (await _userRepository.GetAsync(u => u.UserName == request.UserName)).FirstOrDefault()!;
        Hub? hub = (await _hubRepository.GetAsync(u => u.Id == request.HubId)).FirstOrDefault()!;

        request = request with { HubId = request.HubId };
        var hupAnnoucements = request.Adapt<HubAnnouncement>()!;
        hupAnnoucements.User = creatorUser;
        hupAnnoucements.Hub = hub;



        await _unitOfWork.CreateHubAnnoucementAsync(hupAnnoucements, creatorUser!);
        await _hubAnnouncementRepository.SaveAsync();


        return hupAnnoucements.Adapt<HubAnnouncementReadModel>();


    }
}

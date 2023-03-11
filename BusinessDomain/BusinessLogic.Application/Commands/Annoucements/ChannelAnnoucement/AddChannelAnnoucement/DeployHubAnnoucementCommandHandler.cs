using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Commands.Annoucements.HubAnnoucements;
using BusinessLogic.Application.Commands.Channels.CreateChannel;
using BusinessLogic.Application.Extensions;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Annoucements.ChannelAnnoucements;
using BusinessLogic.Application.Models.Annoucements.HubAnnoucements;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Application.Queries.Hubs.viewHubUsers;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using BusinessLogic.Domain.SharedEnums;
using ErrorOr;
using FluentValidation;
using Mapster;


namespace BusinessLogic.Application.Commands.Annoucements.ChannnelAnnoucement.AddChannelAnnoucement;
public class DeployHubAnnoucementCommandHandler : IHandler<DeployChannelAnnoucementCommand, ErrorOr<ChannelAnnouncementReadModel>>
{

    private readonly IUnitOfWork _unitOfWork;
    private readonly IChannelAnnouncementRepository _channelAnnouncementRepository;
    private readonly IUserRepository _userRepository;
    private readonly IChannelRepository _channelRepository;

    public DeployHubAnnoucementCommandHandler(

        IUnitOfWork unitOfWork, IChannelAnnouncementRepository channelAnnouncementRepository, IUserRepository userRepository, IChannelRepository channelRepository)
    {

        _unitOfWork = unitOfWork;
        _channelAnnouncementRepository = channelAnnouncementRepository;
        _userRepository = userRepository;
        _channelRepository = channelRepository;
    }

    public async Task<ErrorOr<ChannelAnnouncementReadModel>> Handle(DeployChannelAnnoucementCommand request, CancellationToken cancellationToken)
    {
        User? creatorUser = (await _userRepository.GetAsync(u => u.UserName == request.UserName)).FirstOrDefault()!;
        Channel? channel = (await _channelRepository.GetAsync(u => u.Id == request.ChannelId)).FirstOrDefault()!;

        request = request with { ChannelId = request.ChannelId };
        var channelAnnoucements = request.Adapt<ChannelAnnouncement>()!;
        channelAnnoucements.User = creatorUser;
        channelAnnoucements.Channel = channel;



        await _unitOfWork.CreateChannelAnnoucementAsync(channelAnnoucements, creatorUser!);
        await _channelAnnouncementRepository.SaveAsync();


        return channelAnnoucements.Adapt<ChannelAnnouncementReadModel>();


    }
}

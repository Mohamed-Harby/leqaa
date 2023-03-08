using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using FluentValidation;
using Mapster;
using MediatR;

namespace BusinessLogic.Application.Commands.Channels.UpdateChannel;
public class UpdateChannelCommandHandler : IHandler<UpdateChannelCommand, ErrorOr<ChannelWriteModel>>
{
    private readonly IChannelRepository _channelRepository;
    private readonly IHubRepository _hubRepository;
    private readonly IUserRepository _userRepository;
    private readonly IValidator<UpdateChannelCommand> _validator;

    public UpdateChannelCommandHandler(
        IChannelRepository channelRepository,
        IHubRepository hubRepository,
        IUserRepository userRepository,
        IValidator<UpdateChannelCommand> validator)
    {
        _channelRepository = channelRepository;
        _hubRepository = hubRepository;
        _userRepository = userRepository;
        _validator = validator;
    }

    public async Task<ErrorOr<ChannelWriteModel>> Handle(UpdateChannelCommand request, CancellationToken cancellationToken)
    {
        var channel = await _channelRepository.GetByIdAsync(request.Id);

        if (request.Name != null)
            channel.Name = request.Name;

        if (request.Description != null)
            channel.Description = request.Description;

        await _channelRepository.UpdateAsync(channel);
        if (await _userRepository.SaveAsync(cancellationToken) == 0)
        {
            return DomainErrors.Channel.InvalidChannel;
        }
        return channel.Adapt<ChannelWriteModel>();
    }
}

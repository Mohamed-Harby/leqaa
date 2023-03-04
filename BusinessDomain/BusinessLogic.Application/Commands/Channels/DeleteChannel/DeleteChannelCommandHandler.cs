using BusinessLogic.Application.CommandInterfaces;
using BusinessLogic.Application.Commands.Channels.CreateChannel;
using BusinessLogic.Application.Commands.Channels.UpdateChannel;
using BusinessLogic.Application.Interfaces;
using BusinessLogic.Application.Models.Channels;
using BusinessLogic.Domain;
using BusinessLogic.Domain.DomainErrors;
using ErrorOr;
using FluentValidation;
using Mapster;
using MediatR;

namespace BusinessLogic.Application.Commands.Channels.DeleteChannel;


public class DeletePostCommandHandler : IHandler<DeletePostCommand, ErrorOr<Unit>>

{
    private readonly IChannelRepository _channelRepository;
    private readonly IHubRepository _hubRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<DeletePostCommand> _validator;


    public DeletePostCommandHandler(

        IChannelRepository channelRepository,
        IHubRepository hubRepository,
        IUserRepository userRepository,
       IValidator<DeletePostCommand> validator)

    {
        _channelRepository = channelRepository;
        _hubRepository = hubRepository;
        _userRepository = userRepository;
        _validator = validator;

    }

    public async Task<ErrorOr<Unit>> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {

        var result = await _validator.ValidateAsync(request);
        if (!result.IsValid)
        {
            return result.Errors.ConvertAll(
                validationFailure => Error.Validation(
                    validationFailure.PropertyName,
                    validationFailure.ErrorMessage)
            );
        }
        var channel = await _channelRepository.GetByIdAsync(request.ChannelId);
        if (channel is null)
        {
            return DomainErrors.Channel.NotFound;
        }


        _channelRepository.Remove(channel);
       

        // await _channelRepository.DeleteChannelWithUser(channel, creatorUser);
        if (await _unitOfWork.Save() == 0)
        {
            return DomainErrors.Channel.InvalidChannel;
        }
        return Unit.Value;
    }

   
}

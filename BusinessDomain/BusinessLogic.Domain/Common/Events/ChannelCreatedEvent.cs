using MediatR;

namespace BusinessLogic.Domain.Common.Events;
public record ChannelCreatedEvent(Channel channel) : IDomainEvent;
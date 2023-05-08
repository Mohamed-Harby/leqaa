namespace BusinessLogic.Domain.Common.Events;
public record UserJoinedChannelEvent(Guid UserId, Guid ChannelId) : IDomainEvent;
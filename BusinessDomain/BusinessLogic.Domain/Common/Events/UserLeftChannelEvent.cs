namespace BusinessLogic.Domain.Common.Events;
public record UserLeftChannelEvent(Guid UserId, Guid ChannelId) : IDomainEvent;
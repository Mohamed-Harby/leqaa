using MediatR;

namespace BusinessLogic.Domain.Common.Events;
public record RoomCreatedEvent(Room room) : IDomainEvent;
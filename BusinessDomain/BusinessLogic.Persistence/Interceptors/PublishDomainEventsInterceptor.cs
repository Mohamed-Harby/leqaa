using BusinessLogic.Application.Interfaces;
using BusinessLogic.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BusinessLogic.Persistence.Interceptors;
public class PublishDomainEventsInterceptor : SaveChangesInterceptor, IPublishDomainEventsInterceptor
{
    private readonly IPublisher _publisher; //from mediatr
    public PublishDomainEventsInterceptor(IPublisher publisher)
    {
        _publisher = publisher;
    }
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        PublishDomainEvents(eventData.Context!).GetAwaiter().GetResult();
        return base.SavingChanges(eventData, result);
    }
    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        await PublishDomainEvents(eventData.Context!);
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }
    private Task PublishDomainEvents(DbContext context)
    {

        var domainEventEntities = context.ChangeTracker.Entries<IHasDomainEvent>()
            .Where(entry => entry.Entity.DomainEvents.Any())
            .Select(entry => entry.Entity)
            .ToList();


        var domainEvents = domainEventEntities
            .SelectMany(entity => entity.DomainEvents)
            .ToList();
        domainEventEntities.ForEach(entity => entity.ClearDomainEvents());

        domainEvents.ForEach(async domainEvent => await _publisher.Publish(domainEvent));

        return Task.CompletedTask;
    }

}



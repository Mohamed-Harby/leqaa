using System.ComponentModel.DataAnnotations;

namespace BusinessLogic.Domain.Common
{
    public abstract class BaseEntity : IHasDomainEvent
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}
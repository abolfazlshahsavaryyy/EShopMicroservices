
namespace Ordering.Domain.Abstractions
{
    public class Aggregate<TId> : Entity<TId>, IAggregate<TId>
    {
        private readonly List<IDomainEvent> _domainEvents = new(); 
        public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
        
        public IDomainEvent[] ClearDomainEvent()
        {
            IDomainEvent[] dequeuedDomainEvent = _domainEvents.ToArray();
            _domainEvents.Clear();
            return dequeuedDomainEvent;
        }
        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);

        }
    }
}

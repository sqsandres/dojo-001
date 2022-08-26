using Dojo.Bakery.BuildingBlocks.Commons.ModelContracts;

namespace Dojo.Bakery.BuildingBlocks.Commons
{
    public abstract class AggregateRoot : Entity, IAggregateRoot
    {
        private readonly List<IEvent> _domainEvents = new List<IEvent>();
        public virtual IReadOnlyList<IEvent> DomainEvents => this._domainEvents;
        protected virtual void AddDomainEvent(IEvent newEvent)
        {
            _domainEvents.Add(newEvent);
        }
        public virtual void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}

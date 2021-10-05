using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Base
{
    public abstract class BaseEntity
    {
        [NotMapped]
        private List<BaseDomainEvent> _events;
        [NotMapped]
        public IReadOnlyList<BaseDomainEvent> Events => _events.AsReadOnly();

        protected void AddEvent(BaseDomainEvent @event)
        {
            _events.Add(@event);
        }

        protected void RemoveEvent(BaseDomainEvent @event)
        {
            _events.Remove(@event);
        }
    }

    public abstract class BaseEntity<TKey> : BaseEntity
    {
        public TKey Id { get; set; }
    }
}
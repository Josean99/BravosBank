using BravosBank.Shared.EventSourcing.Communications.Events;

namespace BravosBank.Shared.EventSourcing.Persistance
{
    /// <summary>
    /// Abstraction of all aggregates root with all the functionalities
    /// </summary>
    public abstract class AggregateRoot
    {
        protected string _id = string.Empty;
        public string Id { get { return _id; } } //Id of the aggregate root
        public int Version { get; set; } //Version of the next event
        private readonly List<DomainEvent> _changes = new(); //List of events that haven't been commited to DB

        public IEnumerable<DomainEvent> GetUncommittedChanges()
        {
            return _changes;
        }

        public void MarkChangesAsCommitted()
        {
            _changes.Clear();
        }

        public void ApplyChange(DomainEvent @event, bool isNewEvent)
        {
            var method = this.GetType().GetMethod("Apply", [@event.GetType()] );
            if (method == null)
            {
                throw new ArgumentNullException($"The Apply method was not found in the aggregate for event {@event.GetType().Name}");
            }
            method.Invoke(this, [@event] );
            if (isNewEvent)
            {
                _changes.Add(@event);
            }
        }

        public void RaiseEvent(DomainEvent @event) // Add the event to the UncommitedChanges list
        {
            ApplyChange(@event, true);
        }

        public void ReplayEvents(IEnumerable<DomainEvent> events) // Load all the previous events in memory
        {
            foreach (var @event in events)
            {
                ApplyChange(@event, false);
            }
        }
    }
}

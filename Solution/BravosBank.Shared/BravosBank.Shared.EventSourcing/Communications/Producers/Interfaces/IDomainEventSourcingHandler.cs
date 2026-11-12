using EventSourcing.Common.Persistance;

namespace EventSourcing.Common.Communications.Producers.Interfaces
{
    public interface IDomainEventSourcingHandler<T>
    {
        Task<T> GetByIdAsync(string aggregateId, CancellationToken cancellationToken);
        Task SaveAsync(AggregateRoot aggregate, CancellationToken cancellationToken);
    }
}

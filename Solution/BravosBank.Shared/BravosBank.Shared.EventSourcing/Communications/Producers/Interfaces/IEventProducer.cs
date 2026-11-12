using EventSourcing.Common.Communications.Events;
using EventSourcing.Common.Communications.Events.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventSourcing.Common.Communications.Producers.Interfaces
{
    public interface IEventProducer
    {
        Task ProduceDomainEventAsync(string topic, DomainEvent @event);
        Task ProduceIntegrationEventAsync(string topic, IntegrationEvent @event);
    }
}

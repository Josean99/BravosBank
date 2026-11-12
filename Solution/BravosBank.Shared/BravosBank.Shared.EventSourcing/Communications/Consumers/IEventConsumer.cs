using System;
using System.Collections.Generic;
using System.Text;

namespace BravosBank.Shared.EventSourcing.Consumers
{
    public interface IEventConsumer
    {
        Task ConsumeDomainEvents(List<string> topics, CancellationToken cancellationToken);
    }
}

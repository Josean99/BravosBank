using System;
using System.Collections.Generic;
using System.Text;

namespace BravosBank.Shared.EventSourcing.Communications.Events.Base
{
    public enum EventType
    {
        DomainEvent,
        IntegrationEvent
    }
}

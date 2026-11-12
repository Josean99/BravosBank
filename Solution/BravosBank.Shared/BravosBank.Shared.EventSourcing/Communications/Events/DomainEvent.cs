using BravosBank.Shared.EventSourcing.Communications.Events.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BravosBank.Shared.EventSourcing.Communications.Events
{
    public class DomainEvent : BaseEvent
    {
        public DomainEvent(string name) : base(name)
        {
        }

        public override EventType Type { get; set; } = EventType.DomainEvent;
    }
}

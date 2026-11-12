using BravosBank.Shared.EventSourcing.Communications.Events.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace BravosBank.Shared.EventSourcing.Communications.Events
{
    public class IntegrationEvent : BaseEvent
    {
        public IntegrationEvent(string name) : base(name)
        {
        }
        public override EventType Type { get; set; } = EventType.IntegrationEvent;
    }
}

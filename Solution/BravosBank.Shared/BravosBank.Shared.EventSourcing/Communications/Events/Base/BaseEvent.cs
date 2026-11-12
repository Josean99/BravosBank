using System;
using System.Collections.Generic;
using System.Text;

namespace BravosBank.Shared.EventSourcing.Communications.Events.Base
{
    public abstract class BaseEvent : Message
    {
        public BaseEvent(string name)
        {
            Name = name;
        }
        public int Version { get; set; }
        public string Name { get; set; }
        public abstract EventType Type { get; set; }
    }
}

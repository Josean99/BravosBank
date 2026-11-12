using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BravosBank.Shared.EventSourcing.Communications.Events.Base
{
    public abstract class Message
    {
        [BsonId]
        public string Id { get; set; } = string.Empty;

        protected Message()
        {
            
        }
    }
}

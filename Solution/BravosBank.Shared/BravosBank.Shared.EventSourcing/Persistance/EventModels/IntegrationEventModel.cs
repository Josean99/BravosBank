using BravosBank.Shared.EventSourcing.Bson;
using BravosBank.Shared.EventSourcing.Communications.Events;
using BravosBank.Shared.EventSourcing.Persistance.Repositories;
using MongoDB.Bson.Serialization.Attributes;

namespace BravosBank.Shared.EventSourcing.Persistance
{
    [BsonCollection("eventStores")]
    public class IntegrationEventModel : Document
    {
        [BsonElement("timestamp")]
        public DateTime TimeStamp { get; set; }

        [BsonElement("aggregateIdentifier")]
        public required string AggregateIdentifier { get; set; }

        [BsonElement("processedAt")]
        public DateTime ProcessedAt { get; set; }

        [BsonElement("eventType")]
        public string EventType { get; set; } = string.Empty;

        public IntegrationEvent EventData { get; set; }
    }
}

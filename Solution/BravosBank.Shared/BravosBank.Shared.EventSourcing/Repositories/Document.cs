using BravosBank.Shared.EventSourcing.Persistance.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BravosBank.Shared.EventSourcing.Persistance.Repositories
{
    public class Document : IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public ObjectId Id { get; set; }
    }
}

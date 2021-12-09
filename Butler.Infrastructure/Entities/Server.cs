using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Butler.Infrastructure.Entities
{
    internal class Server : BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public ulong Id { get; set; }
        public string Name { get; set; }
        public bool IsConnected { get; set; }
    }
}

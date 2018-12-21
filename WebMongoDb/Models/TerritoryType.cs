using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebMongoDb.Models
{
    public class TerritoryType
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Type")]
        public string Type { get; set; }
    }
}
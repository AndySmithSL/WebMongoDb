using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebMongoDb.Models
{
    public class GeochartLevel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Level")]
        public string Level { get; set; }
    }
}
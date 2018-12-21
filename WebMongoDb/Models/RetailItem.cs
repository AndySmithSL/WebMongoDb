using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMongoDb.Models
{
    public class RetailItem
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("item")]
        public string Item { get; set; }

        [BsonElement("qty")]
        public int Quantity { get; set; }

        [BsonElement("status")]
        public string Status { get; set; }

        [BsonElement("size")]
        public Size Size { get; set; }

        [BsonElement("tags")]
        public List<string> Tags { get; set; }
    }
}

using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMongoDb.Models
{
    public class Size
    {
        [BsonElement("h")]
        public double Height { get; set; }

        [BsonElement("w")]
        public double Width { get; set; }

        [BsonElement("uom")]
        public string UOM { get; set; }
    }
}

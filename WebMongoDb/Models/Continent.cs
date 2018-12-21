using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMongoDb.Models
{
    [BsonDiscriminator(Required = true, RootClass = true)]
    public class Continent
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Code")]
        public string Code { get; set; }

        [BsonElement("ParentId")]
        public ObjectId ParentId { get; set; }


        //public Continent Parent { get; set; }

        public Continent()
        {
            Territories = new HashSet<Territory>();

        }

        public IEnumerable<Territory> Territories { get; set; }

    }
}

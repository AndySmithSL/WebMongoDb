using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMongoDb.Models
{
    public class Territory
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("FullName")]
        public string FullName { get; set; }

        [BsonElement("LocalName")]
        public string LocalName { get; set; }

        [BsonElement("ContinentId")]
        public ObjectId ContinentId { get; set; }

        [BsonElement("ParentId")]
        public ObjectId ParentId { get; set; }

        [BsonElement("Population")]
        public int Population { get; set; }

        [BsonElement("Area")]
        public double Area { get; set; }

        [BsonElement("IsoCode")]
        public string IsoCode { get; set; }

        [BsonElement("Latitude")]
        public double Latitude { get; set; }

        [BsonElement("Longitude")]
        public double Longitude { get; set; }

        [BsonElement("Zoom")]
        public int Zoom { get; set; }

        [BsonElement("TerritoryType")]
        public TerritoryType TerritoryType { get; set; }

        [BsonElement("GeochartLevel")]
        public GeochartLevel GeochartLevel { get; set; }

        [BsonElement("FlagId")]
        public ObjectId FlagId { get; set; }


        public IEnumerable<Continent> Continents { get; set; }

        public Continent Continent { get; set; }

        public Flag Flag { get; set; }
    }
}
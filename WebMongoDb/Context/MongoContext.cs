using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMongoDb.Context
{
    public class MongoContext
    {

        private MongoClient client = null;
        private IMongoDatabase database = null;

        public MongoClient Client
        {
            get => client ?? (client = LoadClient());
            set => client = value;
        }

        public IMongoDatabase Database
        {
            get => database ?? (database = Client.GetDatabase("Factbook"));
            set => database = value;
        }


        public MongoContext()
        {
            //MongoClient client = new MongoClient("mongodb://Andy_Smith:KMZoX7Yy6l8WQLyf@clusterandyred-shard-00-00-wi6nf.azure.mongodb.net:27017,clusterandyred-shard-00-01-wi6nf.azure.mongodb.net:27017,clusterandyred-shard-00-02-wi6nf.azure.mongodb.net:27017/test?ssl=true&replicaSet=ClusterAndyRed-shard-0&authSource=admin&retryWrites=true");
            //var database = client.GetDatabase("Factbook");

            //IMongoCollection<Continent> stuff = database.GetCollection<Continent>("Continent");
        }


        private MongoClient LoadClient()
        {
            try
            {
                return new MongoClient("mongodb://Andy_Smith:KMZoX7Yy6l8WQLyf@clusterandyred-shard-00-00-wi6nf.azure.mongodb.net:27017,clusterandyred-shard-00-01-wi6nf.azure.mongodb.net:27017,clusterandyred-shard-00-02-wi6nf.azure.mongodb.net:27017/test?ssl=true&replicaSet=ClusterAndyRed-shard-0&authSource=admin&retryWrites=true");
            }
            catch (MongoException ex)
            {
                throw new ApplicationException("Cannot connect to the Mongo DB", ex);
            }
        }
    }
}

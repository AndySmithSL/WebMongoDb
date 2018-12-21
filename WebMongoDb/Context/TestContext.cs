using Blueshift.EntityFrameworkCore.MongoDB.Annotations;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMongoDb.Models;

namespace WebMongoDb.Context
{
    [MongoDatabase("Factbook")]
    public class TestContext : DbContext
    {
        private DbSet<Continent> continents = null;

        public DbSet<Continent> Continents
        {
            get => continents ?? (continents = LoadContinents());
            set => continents = value;
        }

        private DbSet<Continent> LoadContinents()
        {
           // DbSet<Continent> result = DbSet


            throw new NotImplementedException();
        }

        public TestContext()
            : this(new DbContextOptions<TestContext>())
        {
        }

        public TestContext(DbContextOptions<TestContext> zooDbContextOptions)
            : base(zooDbContextOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            MongoClient client = new MongoClient("mongodb://Andy_Smith:KMZoX7Yy6l8WQLyf@clusterandyred-shard-00-00-wi6nf.azure.mongodb.net:27017,clusterandyred-shard-00-01-wi6nf.azure.mongodb.net:27017,clusterandyred-shard-00-02-wi6nf.azure.mongodb.net:27017/test?ssl=true&replicaSet=ClusterAndyRed-shard-0&authSource=admin&retryWrites=true");
            
            var database = client.GetDatabase("Factbook");

            IMongoCollection<Continent> stuff = database.GetCollection<Continent>("Continent");

            optionsBuilder.UseMongoDb(client);
        }
    }
}

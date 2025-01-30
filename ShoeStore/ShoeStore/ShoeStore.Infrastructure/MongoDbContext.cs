using MongoDB.Driver;
using ShoeStore.Core.Models;

namespace ShoeStore.Infrastructure
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Shoe> Shoes => _database.GetCollection<Shoe>("Shoes");
        public IMongoCollection<Customer> Customers => _database.GetCollection<Customer>("Customers");
    }
}
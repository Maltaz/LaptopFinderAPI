using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace LaptopFinderAPI
{
    public class MongoDbClientFactory : IMongoClientFactory
    {
        public readonly MongoClient _mongoClient;

        public MongoDbClientFactory(string connectionString)
        {
            var mongoClientSettings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            _mongoClient = new MongoClient(mongoClientSettings);
        }

        public IMongoClient GetMongoClient()
        {
            return _mongoClient;
        }
    }
    //wyjebać gdzieś indziej
    public interface IMongoClientFactory
    {
        IMongoClient GetMongoClient();
    }
}

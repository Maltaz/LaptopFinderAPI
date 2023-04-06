using MongoDB.Driver;

namespace LaptopFinderAPI
{
    public class MongoDbClientFactory
    {
        private readonly MongoClient _mongoClient;

        public MongoDbClientFactory()
        {
            var connectionString = "mongodb://localhost:27017/mydb";
            var mongoClientSettings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            _mongoClient = new MongoClient(mongoClientSettings);
        }

        public IMongoClient GetMongoClient()
        {
            return _mongoClient;
        }
    }
}

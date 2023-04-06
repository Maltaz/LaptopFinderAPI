using Microsoft.AspNetCore.Mvc;
using LaptopFinderAPI.Dtos;
using MongoDB.Bson;
using MongoDB.Driver;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaptopFinderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopFinderController : ControllerBase
    {
        private readonly MongoDbClientFactory _mongoDbClientFactory;
        private readonly IMongoCollection<BsonDocument> _mongo;
        public LaptopFinderController(MongoDbClientFactory mongoDbClientFactory)
        {
            _mongoDbClientFactory = mongoDbClientFactory;
            var mongoClient = mongoDbClientFactory.GetMongoClient();
            var database = mongoClient.GetDatabase("TEST");
            _mongo = database.GetCollection<BsonDocument>("testCollection");
        }

        // POST api/<LaptopFinderController>
        [HttpPost]
        public async Task<ActionResult<IEnumerable<BsonDocument>>> PostSomething(ProductDto value)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId("1"));
            var options = new FindOptions<BsonDocument>();
            var results = await _mongo.FindAsync(filter, options);
            return Ok(await results.ToListAsync());
        }
    }
}

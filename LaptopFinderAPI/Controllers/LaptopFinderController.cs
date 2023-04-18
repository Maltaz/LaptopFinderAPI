using Microsoft.AspNetCore.Mvc;
using LaptopFinderAPI.Dtos;
using MongoDB.Bson;
using MongoDB.Driver;
using Swashbuckle.AspNetCore.Annotations;

namespace LaptopFinderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopFinderController : ControllerBase
    {
        //private readonly MongoDbClientFactory _mongoDbClientFactory;
        //private readonly IMongoCollection<BsonDocument> _mongo;
        //public LaptopFinderController(MongoDbClientFactory mongoDbClientFactory)
        //{
        //    _mongoDbClientFactory = mongoDbClientFactory;
        //    var mongoClient = mongoDbClientFactory.GetMongoClient();
        //    var database = mongoClient.GetDatabase("TEST");
        //    _mongo = database.GetCollection<BsonDocument>("testCollection");
        //}

        //// POST api/<LaptopFinderController>
        //[HttpPost]
        //public async Task<ActionResult<IEnumerable<BsonDocument>>> PostSomething(ProductDto value)
        //{
        //    var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId("1"));
        //    var options = new FindOptions<BsonDocument>();
        //    var results = await _mongo.FindAsync(filter, options);
        //    return Ok(await results.ToListAsync());
        //}

        [HttpPost("predict")]
        [SwaggerResponse(400, "Returned when some value is not provided. (MOCKED. Returned if you send 0 in ignored cases)")]
        [SwaggerResponse(404, "Returned when no laptop matches. (MOCKED. Returned if you send 1 in ignored cases)")]
        [SwaggerResponse(200, "When match found. (Mocked. Returned if 0 and 1 not in ignored cases)",typeof(LaptopDto))]
        public async Task<ActionResult<LaptopDto>> GetLaptop([FromBody] CaseDataDto caseData, [FromQuery] IEnumerable<int> ignoredCases)
        {
            ignoredCases ??= Enumerable.Empty<int>();

            if (ignoredCases.Any(x => x == 0))
            {
                return BadRequest();
            }

            if (ignoredCases.Any(x => x == 1))
            {
                return NotFound();
            }

            var output = new LaptopDto()
            {
                Id = 2137,
                Ram = "12GB",
                Company = "Acer",
                CPU = "Intel Core i5 7200U 2.5GHz",
                ScreenResolution = "Full HD 1920x1080",
                GPU = "Nvidia GeForce GTX 950M",
                TypeName = "Notebook",
                Inches = "15.6",
                Memory = "128GB SSD +  1TB HDD",
                OpSys = "Windows 10",
                Price = "1369.90",
                Product = "Aspire F5-573G-510L",
                Weight = "2.6kg"
            };

            return Ok(Task.FromResult(output));
        }

        [HttpPost("teach/{laptopId}")]
        [SwaggerResponse(400, "Returned when something goes wrong. (MOCKED. Returned when laptopId = 0)")]
        [SwaggerResponse(200, "Returned when teaching goes ok. (MOCKED. Returned when laptopId != 0)")]
        public async Task<ActionResult> TeachAlgorithm([FromBody] CaseDataDto caseData,int laptopId)
        {
            if (laptopId == 0)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}

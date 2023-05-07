using Microsoft.AspNetCore.Mvc;
using LaptopFinderAPI.Dtos;
using MongoDB.Bson;
using MongoDB.Driver;
using Swashbuckle.AspNetCore.Annotations;
using MediatR;
using LaptopFinder.Core.Requests;
using LaptopFinder.Core.Entities;
using AutoMapper;

namespace LaptopFinderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LaptopFinderController : ControllerBase
    {
        private readonly IMongoClientFactory _mongoDbClientFactory;
        private readonly IMongoCollection<BsonDocument> _mongo;
        private readonly ISender sender;
        private readonly IMapper mapper;
        public LaptopFinderController(IMongoClientFactory mongoDbClientFactory, ISender sender, IMapper mapper)
        {
            _mongoDbClientFactory = mongoDbClientFactory;
            var mongoClient = mongoDbClientFactory.GetMongoClient();
            var database = mongoClient.GetDatabase("laptop_finder");
            _mongo = database.GetCollection<BsonDocument>("laptopData");
            
            this.sender = sender;
            this.mapper = mapper;
        }

        // POST api/<LaptopFinderController>
        [HttpPost]
        public async Task<ActionResult<IEnumerable<string>>> PostSomething(ProductDto value)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", new ObjectId("1"));
            var options = new FindOptions<BsonDocument>();
            var results = await _mongo.FindAsync(filter, options);
            return Ok(await results.ToListAsync());
        }

        [HttpPost("predict")]
        [SwaggerResponse(400, "Returned when some value is not provided.", typeof(ValidationProblemDetails))]
        [SwaggerResponse(404, "Returned when no laptop matches. (MOCKED. Returned if you send 0 in ignored cases)")]
        [SwaggerResponse(200, "When match found. (Mocked. Returned if 0 not in ignored cases)",typeof(LaptopDto))]
        public async Task<ActionResult<LaptopDto>> GetLaptop([FromBody] CaseDataDto caseData, [FromQuery] IEnumerable<int> ignoredCases)
        {
            ignoredCases ??= Enumerable.Empty<int>();

            var currentCase = mapper.Map<CaseDataDto,Case>(caseData);

            var query = new GetClosestCaseQuery(ignoredCases, currentCase);

            var matchingLaptop = await sender.Send(query);

            if (matchingLaptop is null)
            {
                return NotFound();
            }

            var output = mapper.Map<Laptop,LaptopDto>(matchingLaptop);

            return Ok(output);
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

            var @case = mapper.Map<Case>(caseData);

            await sender.Send(new TeachAlgorithmCommand(laptopId, @case));

            return Ok();
        }
    }
}

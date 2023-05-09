using LaptopFinder.Core.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Core.Operations;

namespace LaptopFinder.Core.Repositories
{
    public interface ICaseRepository
    {
        Task<IEnumerable<Case>> GetAll();
        Task Add(Case @case);
    }

    public class CaseRepository : ICaseRepository
    {
        private readonly IMongoCollection<Case> _caseCollection;

        public CaseRepository(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("laptop_finder");
            _caseCollection = database.GetCollection<Case>("caseData");
        }
        public Task Add(Case @case)
        {
            return _caseCollection.InsertOneAsync(@case);
        }

        public async Task<IEnumerable<Case>> GetAll()
        {
            return await _caseCollection.AsQueryable().ToListAsync();
        }
    }
}

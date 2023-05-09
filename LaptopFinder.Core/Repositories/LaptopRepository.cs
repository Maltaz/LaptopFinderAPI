using LaptopFinder.Core.Entities;
using MongoDB.Driver;

namespace LaptopFinder.Core.Repositories
{
    public interface ILaptopRepository
    {
        public Task<Laptop> GetLaptopData(int laptopId);
    }

    public class LaptopRepository : ILaptopRepository
    {
        private readonly IMongoCollection<Laptop> _laptopCollection;

        public LaptopRepository(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("laptop_finder");
            _laptopCollection = database.GetCollection<Laptop>("laptopData");
        }

        public async Task<Laptop> GetLaptopData(int laptopId)
        {
            var filter = Builders<Laptop>.Filter.Eq(x => x.Id, laptopId);
            var laptop = await _laptopCollection.FindAsync(filter);

            return await laptop.FirstAsync();
        }
    }
}

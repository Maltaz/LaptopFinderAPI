using LaptopFinder.Core.Entities;

namespace LaptopFinder.Core.Repositories
{
    public interface ICaseRepository
    {
        Task<IEnumerable<Case>> GetAll();
        Task Add(Case @case);
    }

    public class CaseRepository : ICaseRepository
    {
        //TODO
        public Task Add(Case @case)
        {
            return Task.CompletedTask;
        }

        //TODO
        public async Task<IEnumerable<Case>> GetAll()
        {
            var @case = new Case()
            {
                Id = 2137,
                LaptopId = 0,
                AudioQuality = 5,
                BatteryTime = 5,
                Small = 5,
                DiskSize = 5,
                Efficiency = 5,
                GraphicsQuality = 5,
                KeyboardLight = 4,
                Light = 5
            };

            return new List<Case> { @case };
        }
    }
}

using LaptopFinder.Core.Entities;

namespace LaptopFinder.Core.Services
{
    public interface ICBRService
    {
        public Case? FindClosestCase(IEnumerable<Case> allCases, Case existingCase);
    }
}

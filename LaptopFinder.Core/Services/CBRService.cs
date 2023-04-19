using LaptopFinder.Core.Entities;

namespace LaptopFinder.Core.Services
{
    public class CBRService : ICBRService
    {
        public Case? FindClosestCase(IEnumerable<Case> allCases, Case existingCase)
        {
            if (allCases is null || !allCases.Any())
                return null;

            var distanceCollection = allCases.Select(x => new { Case = x, Distance = x.GetDistance(existingCase) });

            if (distanceCollection is null || !distanceCollection.Any())
                return null;

            return distanceCollection.MinBy(x => x.Distance)!.Case;
        }
    }
}
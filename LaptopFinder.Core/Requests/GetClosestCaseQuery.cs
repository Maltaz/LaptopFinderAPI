using LaptopFinder.Core.Entities;
using LaptopFinder.Core.Repositories;
using LaptopFinder.Core.Services;
using MediatR;

namespace LaptopFinder.Core.Requests
{
    public class GetClosestCaseQuery : IRequest<Laptop?>
    {
        public IEnumerable<int> IgnoredLaptops { get; }
        public Case CurrentCase { get; }

        public GetClosestCaseQuery(IEnumerable<int> ignoredLaptops, Case currentCase)
        {
            IgnoredLaptops = ignoredLaptops;
            this.CurrentCase = currentCase;
        }
    }

    public class GetClosestCaseHandler : IRequestHandler<GetClosestCaseQuery, Laptop?>
    {
        private readonly ICBRService cbrService;
        private readonly ICaseRepository caseRepo;
        private readonly ILaptopRepository laptopRepo;

        public GetClosestCaseHandler(
            ICBRService cbrService,
            ICaseRepository caseRepo,
            ILaptopRepository laptopRepo)
        {
            this.cbrService = cbrService;
            this.caseRepo = caseRepo;
            this.laptopRepo = laptopRepo;
        }

        public async Task<Laptop?> Handle(GetClosestCaseQuery request, CancellationToken cancellationToken)
        {
            var allCases = await caseRepo.GetAll();
            if (allCases is null || !allCases.Any())
                return null;

            var filteredCases = allCases.Where(ac => !request.IgnoredLaptops.Contains(ac.LaptopId));
            if (filteredCases is null || !filteredCases.Any())
                return null;

            var closestCase = cbrService.FindClosestCase(filteredCases, request.CurrentCase);
            if (closestCase is null)
                return null;

            var laptopData = await laptopRepo.GetLaptopData(closestCase.LaptopId);

            return laptopData;
        }
    }
}

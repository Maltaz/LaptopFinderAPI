using LaptopFinder.Core.Entities;
using LaptopFinder.Core.Repositories;
using MediatR;

namespace LaptopFinder.Core.Requests
{
    public class TeachAlgorithmCommand : IRequest<Unit>
    {
        public int LaptopId { get; }
        public Case CurrentCase { get; }

        public TeachAlgorithmCommand(int laptopId, Case currentCase)
        {
            LaptopId = laptopId;
            CurrentCase = currentCase;
        }
    }

    public class TeachAlgorithmHandler : IRequestHandler<TeachAlgorithmCommand, Unit>
    {
        private readonly ICaseRepository caseRepo;

        public TeachAlgorithmHandler(ICaseRepository caseRepo)
        {
            this.caseRepo = caseRepo;
        }

        public async Task<Unit> Handle(TeachAlgorithmCommand request, CancellationToken cancellationToken)
        {
            var @case = request.CurrentCase;
            @case.LaptopId = request.LaptopId;

            await caseRepo.Add(@case);

            return Unit.Value;
        }
    }
}

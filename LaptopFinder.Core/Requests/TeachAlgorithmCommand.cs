using LaptopFinder.Core.Entities;
using MediatR;

namespace LaptopFinder.Core.Requests
{
    public class TeachAlgorithmCommand : IRequest<Unit>
    {

    }

    public class TeachAlgorithmHandler : IRequestHandler<TeachAlgorithmCommand, Unit>
    {
        public Task<Unit> Handle(TeachAlgorithmCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

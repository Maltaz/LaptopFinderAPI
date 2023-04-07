using LaptopFinder.Core.Entities;
using MediatR;

namespace LaptopFinder.Core.Requests
{
    public class GetCaseQuery : IRequest<Laptop>
    {

    }

    public class GetCaseHandler : IRequestHandler<GetCaseQuery, Laptop>
    {
        public Task<Laptop> Handle(GetCaseQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

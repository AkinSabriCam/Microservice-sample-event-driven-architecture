using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Customer.Domain;
using MediatR;

namespace Customer.Application.Queries
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery,List<Domain.Customer>>
    {
        private readonly IRepository _repository;

        public GetAllCustomersQueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Domain.Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetAll();
        }
    }
}
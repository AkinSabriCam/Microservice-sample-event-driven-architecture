using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Notification.Domain;

namespace Notification.Application.Customer
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery,List<Domain.Customer>>
    {
        private readonly ICustomerRepository _repository;

        public GetAllCustomersQueryHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Domain.Customer>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetAll();
        }
    }
}
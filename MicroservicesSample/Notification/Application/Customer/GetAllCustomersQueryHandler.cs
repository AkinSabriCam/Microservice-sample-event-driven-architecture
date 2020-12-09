using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Notification.Domain;
using Notification.Mapping;

namespace Notification.Application.Customer
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery,List<CustomerDto>>
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCustomersQueryHandler(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        { 
            var result = await _repository.GetAll();
            return _mapper.Map<List<CustomerDto>>(result);
        }
    }
}
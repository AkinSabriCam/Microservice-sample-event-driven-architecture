using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Identity.Domain;
using MediatR;

namespace Identity.Application.Queries
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery,List<User>>
    {
        private readonly IRepository _repository;

        public GetAllUsersQueryHandler(IRepository repository)
        {
            _repository = repository;
        }

        public Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetAll();
        }
    }
}
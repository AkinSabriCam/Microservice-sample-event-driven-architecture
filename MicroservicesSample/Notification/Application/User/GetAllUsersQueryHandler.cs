using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Notification.Domain;

namespace Notification.Application.User
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery,List<Domain.User>>
    {
        private readonly IUserRepository _repository;

        public GetAllUsersQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public Task<List<Domain.User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetAll();
        }
    }
}
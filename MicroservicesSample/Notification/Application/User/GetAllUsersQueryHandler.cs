using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Notification.Domain;
using Notification.Mapping;

namespace Notification.Application.User
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery,List<UserDto>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await  _repository.GetAll();
            return _mapper.Map<List<UserDto>>(result);
        }
    }
}
using System.Collections.Generic;
using Identity.Domain;
using MediatR;

namespace Identity.Application.Queries
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {
        
    }
}
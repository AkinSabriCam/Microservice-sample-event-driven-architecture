using System.Collections.Generic;
using MediatR;

namespace Customer.Application.Queries
{
    public class GetAllCustomersQuery : IRequest<List<Domain.Customer>>
    {
        
    }
}
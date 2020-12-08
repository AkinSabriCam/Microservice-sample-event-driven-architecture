using System.Collections.Generic;
using MediatR;

namespace Notification.Application.Customer
{
    public class GetAllCustomersQuery : IRequest<List<Domain.Customer>>
    {
        
    }
}
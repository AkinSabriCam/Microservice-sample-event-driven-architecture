using System;
using MediatR;

namespace Customer.Application.Commands
{
    public class UpdateCustomerCommand : IRequest<Domain.Customer>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
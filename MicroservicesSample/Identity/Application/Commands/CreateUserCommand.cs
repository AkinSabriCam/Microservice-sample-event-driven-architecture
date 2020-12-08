using Identity.Domain;
using MediatR;

namespace Identity.Application.Commands
{
    public class CreateUserCommand : IRequest <User>
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
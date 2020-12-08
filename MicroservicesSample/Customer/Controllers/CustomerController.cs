using System.Threading.Tasks;
using Customer.Application.Commands;
using Customer.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPut]
        public async Task<ActionResult<Domain.Customer>> UpdateAsync(UpdateCustomerCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        public async Task<ActionResult<Domain.Customer>> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllCustomersQuery()));
        }
    }
}
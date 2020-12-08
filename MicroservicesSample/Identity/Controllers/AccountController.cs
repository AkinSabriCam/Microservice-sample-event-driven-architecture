using System.Collections.Generic;
using System.Threading.Tasks;
using Identity.Application.Commands;
using Identity.Application.Queries;
using Identity.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Register(CreateUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllUsersQuery()));
        }
    }
}
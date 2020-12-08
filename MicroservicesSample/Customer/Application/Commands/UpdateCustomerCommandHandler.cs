using System.Threading;
using System.Threading.Tasks;
using Common.Event;
using Customer.Domain;
using Customer.EntityFramework;
using MediatR;

namespace Customer.Application.Commands
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Domain.Customer>
    {
        private readonly IRepository _repository;
        private readonly CustomerDbContext _dbContext;
        private readonly IMassTransitEventProducer _eventProducer;

        public UpdateCustomerCommandHandler(
            IRepository repository, 
            CustomerDbContext dbContext, 
            IMassTransitEventProducer eventProducer)
        {
            _repository = repository;
            _dbContext = dbContext;
            _eventProducer = eventProducer;
        }

        public async Task<Domain.Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetById(request.Id);
            customer.Email = request.Email;
            customer.FirstName = request.FirstName;
            customer.LastName = request.LastName;

            var result = await _repository.Update(customer);
            await _dbContext.SaveChangesAsync(cancellationToken);

            // CustomerUpdatedEvent produce edilecek
            await _eventProducer.Publish(new UserUpdatedEvent
            {
                Id = result.Id,
                Email = result.Email,
                FirstName = result.FirstName,
                LastName = result.LastName
            });

            return result;
        }
    }
}
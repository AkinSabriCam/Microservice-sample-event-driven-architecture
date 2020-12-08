using System.Threading;
using System.Threading.Tasks;
using Common.Event;
using Identity.Domain;
using Identity.EntityFramework;
using MediatR;

namespace Identity.Application.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IRepository _repository;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMassTransitEventProducer _massTransitEventProducer;

        public CreateUserCommandHandler(
            IRepository repository, 
            ApplicationDbContext dbContext,
            IMassTransitEventProducer massTransitEventProducer)
        {
            _repository = repository;
            _dbContext = dbContext;
            _massTransitEventProducer = massTransitEventProducer;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.Add(new User
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName
            });
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            // burada event fırlatılacak (CreatedUserEvent)
            await _massTransitEventProducer.Publish(new UserCreatedEvent
                {Email = user.Email, Id = user.Id, FirstName = user.FirstName, LastName = user.LastName});
            
            return user;
        }
    }
}
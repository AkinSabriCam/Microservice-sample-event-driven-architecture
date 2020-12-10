using System.Threading.Tasks;
using Common.Event;
using Customer.EntityFramework;

namespace Customer.Domain.EventListeners
{
    public class UserCreatedEventListener : IEventHandler<UserCreatedEvent>
    {
        private readonly IRepository _repository;
        private readonly CustomerDbContext _dbContext;

        public UserCreatedEventListener(IRepository repository, CustomerDbContext dbContext)
        {
            _repository = repository;
            _dbContext = dbContext;
        }
        
        public async Task Handle(UserCreatedEvent userEvent)
        {
            await _repository.Add(new Customer
            {
                Id = userEvent.Id,
                Email = userEvent.Email,
                FirstName = userEvent.FirstName,
                LastName = userEvent.LastName
            });
            
            await _dbContext.SaveChangesAsync();
        }
    }
}
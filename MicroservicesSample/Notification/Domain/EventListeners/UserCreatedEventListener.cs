using System.Threading.Tasks;
using Common.Event;
using MediatR;
using Notification.EntityFramework;

namespace Notification.Domain.EventListeners
{
    public class UserCreatedEventListener : IEventHandler<UserCreatedEvent>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;
        private readonly NotificationDbContext _dbContext;

        public UserCreatedEventListener(
            ICustomerRepository customerRepository,
            IUserRepository userRepository,
            NotificationDbContext dbContext)
        {
            _customerRepository = customerRepository;
            _userRepository = userRepository;
            _dbContext = dbContext;
        }

        public async Task Handle(UserCreatedEvent @event)
        {
            var customer = await _customerRepository.Add(new Customer
            {
                Id = @event.Id,
                Email = @event.Email,
                FirstName = @event.FirstName,
                LastName = @event.LastName
            });

            var user = await _userRepository.Add(new User
            {
                Id = @event.Id,
                FirstName = @event.FirstName,
                LastName = @event.LastName,
                Email = @event.Email
            });

            await _dbContext.SaveChangesAsync();
        }
    }
}
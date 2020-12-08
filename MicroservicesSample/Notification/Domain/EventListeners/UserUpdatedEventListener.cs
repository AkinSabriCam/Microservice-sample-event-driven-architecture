using System.Threading.Tasks;
using Common.Event;
using Notification.EntityFramework;

namespace Notification.Domain.EventListeners
{
    public class UserUpdatedEventListener : IEventHandler<UserUpdatedEvent>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly NotificationDbContext _dbContext;

        public UserUpdatedEventListener(
            IUserRepository userRepository,
            ICustomerRepository customerRepository,
            NotificationDbContext dbContext)
        {
            _userRepository = userRepository;
            _customerRepository = customerRepository;
            _dbContext = dbContext;
        }

        public async Task Handle(UserUpdatedEvent @event)
        {
            var updatedUser = _userRepository.Update(new User
            {
                Id = @event.Id,
                Email = @event.Email,
                FirstName = @event.FirstName,
                LastName = @event.LastName
            });

            var updatedCustomer = _customerRepository.Update(new Customer
            {
                Id = @event.Id,
                FirstName = @event.FirstName,
                LastName = @event.LastName,
                Email = @event.Email
            });

            await updatedUser;
            await updatedCustomer;
            await _dbContext.SaveChangesAsync();
        }
    }
}
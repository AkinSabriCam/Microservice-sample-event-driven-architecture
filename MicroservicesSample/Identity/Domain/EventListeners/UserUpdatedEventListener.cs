using System.Threading.Tasks;
using Common.Event;
using Identity.EntityFramework;

namespace Identity.Domain.EventListeners
{
    public class UserUpdatedEventListener  : IEventHandler<UserUpdatedEvent>
    {
        private readonly IRepository _repository;
        private readonly ApplicationDbContext _dbContext;

        public UserUpdatedEventListener(IRepository repository, ApplicationDbContext dbContext)
        {
            _repository = repository;
            _dbContext = dbContext;
        }

        public async Task Handle(UserUpdatedEvent userEvent)
        {
            var user = await _repository.GetById(userEvent.Id);

            user.FirstName = userEvent.FirstName;
            user.LastName = userEvent.LastName;
            user.Email = userEvent.Email;

            await _repository.Update(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Customer.EntityFramework
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly CustomerDbContext _customerDbContext;

        public DatabaseInitializer(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }

        public Task MigrateAll()
        {
            return _customerDbContext.Database.MigrateAsync();
        }
    }
}
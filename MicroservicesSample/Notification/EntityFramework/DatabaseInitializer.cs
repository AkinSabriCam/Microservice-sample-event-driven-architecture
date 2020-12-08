using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Notification.EntityFramework
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly NotificationDbContext _dbContext;

        public DatabaseInitializer(NotificationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public Task MigrateAll()
        {
            return _dbContext.Database.MigrateAsync();
        }
    }
}
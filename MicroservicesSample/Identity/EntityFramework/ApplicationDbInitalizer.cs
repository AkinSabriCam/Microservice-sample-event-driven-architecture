using System.Threading.Tasks;

namespace Identity.EntityFramework
{
    public class ApplicationDbInitalizer : IApplicationDbInitalizer
    {
        private readonly IApplicationDbContext _dbContext;

        public ApplicationDbInitalizer(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public Task MigrateAll()
        {
            return _dbContext.MigrateAll();
        }
    }
}
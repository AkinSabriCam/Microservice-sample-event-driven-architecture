using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Identity.EntityFramework
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());
        }

        public Task MigrateAll()
        {
            return this.Database.MigrateAsync();
        }
    }
}
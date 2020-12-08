using Microsoft.EntityFrameworkCore;

namespace Customer.EntityFramework
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base (options)
        {
                
        }
        
        public DbSet<Domain.Customer> Customers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CustomerTypeConfiguration());
        }
    }
}
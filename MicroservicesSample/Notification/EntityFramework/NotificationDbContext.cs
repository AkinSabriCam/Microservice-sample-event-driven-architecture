using Microsoft.EntityFrameworkCore;
using Notification.Domain;

namespace Notification.EntityFramework
{
    public class NotificationDbContext : DbContext
    {
        public NotificationDbContext(DbContextOptions<NotificationDbContext> options) : base(options)
        {
                
        }
    
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CustomerTypeConfiguration());
            builder.ApplyConfiguration(new UserTypeConfiguration());
        }
    }
}
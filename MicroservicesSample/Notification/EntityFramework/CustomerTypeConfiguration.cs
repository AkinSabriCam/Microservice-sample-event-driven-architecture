using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notification.Domain;

namespace Notification.EntityFramework
{
    public class CustomerTypeConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Email).IsUnique();
            
            builder.Property(x => x.Email).HasColumnName(nameof(Customer.Email));
            builder.Property(x => x.FirstName).HasColumnName(nameof(Customer.FirstName));
            builder.Property(x => x.LastName).HasColumnName(nameof(Customer.LastName));
        }
    }
}
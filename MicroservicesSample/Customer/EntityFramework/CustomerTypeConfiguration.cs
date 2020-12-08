using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customer.EntityFramework
{
    public class CustomerTypeConfiguration : IEntityTypeConfiguration<Domain.Customer>
    {
        public void Configure(EntityTypeBuilder<Domain.Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Email).IsUnique();
            
            builder.Property(x => x.Email).HasColumnName(nameof(Domain.Customer.Email));
            builder.Property(x => x.FirstName).HasColumnName(nameof(Domain.Customer.FirstName));
            builder.Property(x => x.LastName).HasColumnName(nameof(Domain.Customer.LastName));
        }
    }
}
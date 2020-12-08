using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notification.Domain;

namespace Notification.EntityFramework
{
    public class UserTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Email).IsUnique();
            
            builder.Property(x => x.Email).HasColumnName(nameof(User.Email));
            builder.Property(x => x.FirstName).HasColumnName(nameof(User.FirstName));
            builder.Property(x => x.LastName).HasColumnName(nameof(User.LastName));
        }
    }
}
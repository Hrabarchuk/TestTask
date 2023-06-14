using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(e => e.ListOfTasksToUsers)
                .WithOne(e => e.User);
        }
    }
}

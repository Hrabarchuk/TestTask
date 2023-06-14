using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Security.Claims;

namespace Persistence.Configuration
{
    public class ListOfTaskConfiguration : IEntityTypeConfiguration<ListOfTask>
    {
        public void Configure(EntityTypeBuilder<ListOfTask> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(e => e.ListOfTasksToUsers)
                            .WithOne(e => e.ListOfTasks);
        }
    }
}

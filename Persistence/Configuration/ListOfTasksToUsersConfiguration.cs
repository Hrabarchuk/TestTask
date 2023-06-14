using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class ListOfTasksToUsersConfiguration : IEntityTypeConfiguration<ListOfTasksToUsers>
    {
        public void Configure(EntityTypeBuilder<ListOfTasksToUsers> builder)
        {
            builder.HasKey(x => new { x.ListOfTasksId, x.UserId });

            builder.HasOne(e => e.User)
                .WithMany(e => e.ListOfTasksToUsers)
                .HasForeignKey(e => e.UserId)
                .IsRequired();

            builder.HasOne(e => e.ListOfTasks)
                .WithMany(e => e.ListOfTasksToUsers)
                .HasForeignKey(e => e.ListOfTasksId)
                .IsRequired();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.UserAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.UserName).IsRequired().HasMaxLength(250);
            builder.Property(u => u.Password).IsRequired().HasMaxLength(250);

            builder.HasMany(u => u.TdoLists).WithOne(t => t.User)
                .HasForeignKey(t => t.UserId).OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new List<User>()
            {
                new User()
                {
                    Id = 1, UserName = "mmd", Password = "123",
                    CreatedAt = new DateTime(2024, 12, 12, 12, 12, 12, DateTimeKind.Local),
                },
                new User()
                {
                    Id = 2, UserName = "mahdi", Password = "123",
                    CreatedAt = new DateTime(2024, 12, 12, 12, 12, 12, DateTimeKind.Local),
                },
                new User()
                {
                    Id = 3, UserName = "ali", Password = "123",
                    CreatedAt = new DateTime(2024, 12, 12, 12, 12, 12, DateTimeKind.Local),
                }
            });



        }
    }
}

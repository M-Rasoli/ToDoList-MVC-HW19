using App.Domain.Core.CategoryAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infrastructure.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Title).IsRequired().HasMaxLength(250);
            builder.HasMany(c => c.TodoLists).WithOne(t => t.Category)
                .HasForeignKey(c => c.CategoryId).OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new List<Category>()
            {
                new Category()
                    { Id = 1, Title = "شخصی", CreatedAt = new DateTime(2024, 12, 12, 12, 12, 12, DateTimeKind.Local) },
                new Category()
                    { Id = 2, Title = "کاری", CreatedAt = new DateTime(2024, 12, 12, 12, 12, 12, DateTimeKind.Local) },
                new Category()
                    { Id = 3, Title = "دانشگاهی", CreatedAt = new DateTime(2024, 12, 12, 12, 12, 12, DateTimeKind.Local) },
                new Category()
                    { Id = 4, Title = "سایر", CreatedAt = new DateTime(2024, 12, 12, 12, 12, 12, DateTimeKind.Local) },
            });
        }
    }
}

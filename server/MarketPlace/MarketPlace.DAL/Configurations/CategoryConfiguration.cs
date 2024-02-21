using MarketPlace.DAL.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketPlace.DAL.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.HasMany(c => c.Products)
                .WithOne(p => p.CategoryEntity)
                .HasForeignKey(p => p.CategoryId)
                .IsRequired();

            builder.HasMany(c => c.SubCategories)
                .WithOne(s => s.ParrentCategory)
                .HasForeignKey(s => s.ParrentId);
        }
    }
}

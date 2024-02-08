using MarketPlace.DAL.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketPlace.DAL.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(p => p.CategoryEntity)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .IsRequired();

            builder.HasOne(p => p.Seller)
                .WithMany(s => s.Products)
                .HasForeignKey(p => p.SellerId)
                .IsRequired();

            builder.HasMany(p => p.Reviews)
                .WithOne(r => r.Product)
                .HasForeignKey(r => r.ProductId);
        }
    }
}

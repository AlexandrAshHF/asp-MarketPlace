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

            builder.HasOne(c => c.CategoryEntity)
                    .WithMany(c => c.Products)
                    .HasForeignKey(c => c.Id)
                    .IsRequired();

            
        }
    }
}

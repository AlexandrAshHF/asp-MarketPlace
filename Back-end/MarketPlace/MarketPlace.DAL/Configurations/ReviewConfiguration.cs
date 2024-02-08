using MarketPlace.DAL.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketPlace.DAL.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<ReviewEntity>
    {
        public void Configure(EntityTypeBuilder<ReviewEntity> builder)
        {
            builder.HasOne(r => r.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(p => p.ProductId);
        }
    }
}

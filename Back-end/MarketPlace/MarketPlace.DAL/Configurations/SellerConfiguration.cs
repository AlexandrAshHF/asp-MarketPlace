using MarketPlace.DAL.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketPlace.DAL.Configurations
{
    public class SellerConfiguration : IEntityTypeConfiguration<SellerEntity>
    {
        public void Configure(EntityTypeBuilder<SellerEntity> builder)
        {
            builder.HasMany(s => s.Products)
                .WithOne(p => p.Seller)
                .HasForeignKey(p => p.SellerId)
                .IsRequired();

            builder.HasOne(s => s.User)
                .WithOne(u => u.Seller)
                .HasForeignKey<UserEntity>(u => u.SellerId)
                .IsRequired();
        }
    }
}

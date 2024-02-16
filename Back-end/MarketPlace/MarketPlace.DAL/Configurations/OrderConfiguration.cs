using MarketPlace.DAL.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketPlace.DAL.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasOne(x => x.User)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.UserId)
                .IsRequired();

            builder.HasOne(x => x.Place)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.PlaceId);

            builder.HasMany(x => x.Products)
                .WithMany(x => x.Orders)
                .UsingEntity(
                    "OrderProduct",
                    l => l.HasOne(typeof(ProductEntity)).WithMany().HasForeignKey("ProductFK").OnDelete(DeleteBehavior.Restrict),
                    r => r.HasOne(typeof(OrderEntity)).WithMany().HasForeignKey("OrderFK").OnDelete(DeleteBehavior.Restrict)
                );
        }
    }
}

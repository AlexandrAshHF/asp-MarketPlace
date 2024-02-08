using MarketPlace.DAL.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketPlace.DAL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasOne(u => u.Seller)
                .WithOne(s => s.User)
                .HasForeignKey<SellerEntity>(s => s.UserId);
        }
    }
}

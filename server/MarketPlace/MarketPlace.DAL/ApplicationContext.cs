using MarketPlace.DAL.Configurations;
using MarketPlace.DAL.Enities;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.DAL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
        public DbSet<SellerEntity> Sellers { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<PlaceEntity> Places { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            modelBuilder.ApplyConfiguration(new SellerConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new PlaceConfiguration());

            var productId = Guid.NewGuid();
            var categoryId = Guid.NewGuid();
            var userId = Guid.NewGuid();
            var sellerId = Guid.NewGuid();

            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                Id = userId,
                Email = "test@gmail.com",
                EmailConfirm = true,
                Username = "TestUsername",
                Role = "Seller",
                SellerId = sellerId,
                PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword("TestPassword")
            });

            modelBuilder.Entity<SellerEntity>().HasData(new SellerEntity
            {
                Id = sellerId,
                UserId = userId,
                PhoneNumber = "+375202841621"
            });

            modelBuilder.Entity<CategoryEntity>().HasData(new CategoryEntity
            {
                Id = categoryId,
                SubCategories = null,
                ParrentCategory = null,
                Title = "TestTitle",
                Characteristics = new List<string>()
            });

            modelBuilder.Entity<ProductEntity>().HasData(new ProductEntity
            {
                Id = productId,
                Title = "TestTitle",
                TypeName = "TestTypeName",
                Description = "Description",
                ImageLinks = new List<string>(),
                Price = 5.5M,
                CategoryId = categoryId,
                SellerId = sellerId,
                Reviews = new List<ReviewEntity>(),
                Orders = new List<OrderEntity>()
            });
        }
    }
}

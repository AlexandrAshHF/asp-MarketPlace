using MarketPlace.DAL;
using MarketPlace.DAL.Enities;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.UnitTests.Common
{
    public class ContextFactory
    {
        public static Guid ProductAId = Guid.NewGuid();
        public static Guid ProductBId = Guid.NewGuid();

        public static Guid CategoryAId = Guid.NewGuid();
        public static Guid CategoryBId = Guid.NewGuid();
        public static Guid CategoryAAId = Guid.NewGuid();

        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static Guid SellerAId = Guid.NewGuid();

        public static ApplicationContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            ApplicationContext context = new ApplicationContext(options);

            context.Database.EnsureCreated();

            context.AddRange
                (
                new UserEntity
                {
                    Id = UserAId,
                    Email = "userA@gmail.com",
                    EmailConfirm = true,
                    PasswordHash = Guid.NewGuid().ToString(),
                    Role = string.Empty,
                    Username = "userAum",
                },
                new UserEntity
                {
                    Id = UserBId,
                    Email = "userB@gmail.com",
                    EmailConfirm = true,
                    PasswordHash = Guid.NewGuid().ToString(),
                    Role = "Seller",
                    Username = "userBum",
                    SellerId = SellerAId
                }
                );

            context.AddRange
                (
                new SellerEntity
                {
                    Id = SellerAId,
                    PhoneNumber = "+375000000000",
                    UserId = UserBId,
                    Products = new List<ProductEntity>(),
                }
                );

            context.AddRange
                (
                new CategoryEntity
                {
                    Id = CategoryAId,
                    Title = "CategoryATitle",
                    Characteristics = new List<string>(),
                    ParrentCategory = null,
                    SubCategories = new List<CategoryEntity>()
                },
                new CategoryEntity
                {
                    Id = CategoryBId,
                    Title = "CategoryBTitle",
                    ParrentCategory = null,
                    Characteristics = new List<string>(),
                    SubCategories = new List<CategoryEntity>()
                },
                new CategoryEntity
                {
                    Id = CategoryAAId,
                    Title = "CategoryAATitle",
                    ParrentId = CategoryAId,
                    Characteristics = new List<string>(),
                    SubCategories = new List<CategoryEntity>()
                }
                );

            context.AddRange
                (
                new ProductEntity
                {
                    Id = ProductAId,
                    Title = "Title1",
                    TypeName = "TypeName1",
                    Description = "Description1",
                    ImageLinks = new List<string>(),
                    Price = 1.5M,
                    SellerId = SellerAId,
                    CategoryId = CategoryAId,
                    Reviews = new List<ReviewEntity>(),
                    Orders = new List<OrderEntity>(),
                },
                new ProductEntity
                {
                    Id = ProductBId,
                    Title = "Title2",
                    TypeName = "TypeName2",
                    Description = "Description2",
                    ImageLinks = new List<string>(),
                    Price = 10.5M,
                    SellerId = SellerAId,
                    CategoryId = CategoryBId,
                    Reviews = new List<ReviewEntity>(),
                    Orders = new List<OrderEntity>(),
                }
                );

            context.SaveChanges();

            return context;
        }
        public static void Destroy(ApplicationContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
using MarketPlace.DAL;
using MarketPlace.DAL.Enities;
using Microsoft.EntityFrameworkCore;

namespace MarketPalce.UnitTests.Common
{
    internal class ContextFactory
    {
        public static Guid FirstUserId = Guid.NewGuid();
        public static Guid SecondUserId = Guid.NewGuid();

        public static Guid SellerId = Guid.NewGuid();

        public static Guid FirstCategoryId = Guid.NewGuid();
        public static Guid SecondCategoryId = Guid.NewGuid();
        public static Guid ThirdCategoryId = Guid.NewGuid();

        public static Guid FirstProductId = Guid.NewGuid();
        public static Guid SecondProductId = Guid.NewGuid();

        public static Guid FirstReviewId = Guid.NewGuid();
        public static Guid SecondReviewId = Guid.NewGuid();
        public static ApplicationContext Create()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new ApplicationContext(options);
            context.Database.EnsureCreated();

            #region Users add
            context.AddRange
                (
                    new UserEntity
                    {
                        Id = FirstUserId,
                        Email = "test1@gmail.com",
                        EmailConfirm = true,
                        PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword("password1"),
                        Role = string.Empty,
                        Username = "username1",
                    },
                    new UserEntity
                    {
                        Id = SecondUserId,
                        Email = "test2@gmail.com",
                        EmailConfirm = true,
                        PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword("password2"),
                        Role = "Seller",
                        Username = "username2",
                    }
                );
            #endregion
            #region Sellers add
            context.AddRange
                (
                new SellerEntity
                {
                    Id = SellerId,
                    PhoneNumber = "+3750000000",
                    Products = new List<ProductEntity>(),
                    UserId = SecondUserId
                }
                );
            #endregion
            #region Categories add
            context.AddRange
                (
                    new CategoryEntity
                    {
                        Id = FirstCategoryId,
                        Characteristics = new List<string>(),
                        Title = "Title1",
                        ParrentCategory = null,
                        SubCategories = new List<CategoryEntity>()
                    },
                    new CategoryEntity
                    {
                        Id = SecondCategoryId,
                        Characteristics = new List<string>(),
                        Title = "Title2",
                        ParrentCategory = null,
                        SubCategories = new List<CategoryEntity>()
                    },
                    new CategoryEntity
                    {
                        Id = ThirdCategoryId,
                        Characteristics = new List<string>(),
                        Title = "Title3",
                        ParrentId = FirstCategoryId,
                        SubCategories = new List<CategoryEntity>()
                    }
                );
            #endregion
            #region Products add
            context.AddRange
                (
                    new ProductEntity
                    {
                        Id = FirstProductId,
                        Reviews = new List<ReviewEntity>(),
                        Title = "Title1",
                        TypeName = "Typename1",
                        Description = "Descritption1",
                        Price = 1.0M,
                        ImageLinks = new List<string>(),
                        SellerId = SellerId,
                        Orders = new List<OrderEntity>(),
                        CategoryId = SecondCategoryId,
                    },
                     new ProductEntity
                     {
                         Id = SecondProductId,
                         Reviews = new List<ReviewEntity>(),
                         Title = "Title1",
                         TypeName = "Typename1",
                         Description = "Descritption1",
                         Price = 1.0M,
                         ImageLinks = new List<string>(),
                         Orders = new List<OrderEntity>(),
                         SellerId = SellerId,
                         CategoryId = ThirdCategoryId,
                     }
                );
            #endregion
            #region Reviews add
            context.AddRange
                (
                new ReviewEntity
                {
                    Id = FirstReviewId,
                    Text = "Text1",
                    Rating = 3.5,
                    Username = "username1",
                    DateOfCreate = DateTime.Now,
                    ProductId = FirstProductId,
                },
                new ReviewEntity
                {
                    Id = SecondReviewId,
                    Text = "Text2",
                    Rating = 3.5,
                    Username = "username2",
                    DateOfCreate = DateTime.Now,
                    ProductId = SecondProductId,
                }
                );
            #endregion

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
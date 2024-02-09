using MarketPlace.Core.Interfaces.Repositories;
using MarketPlace.Core.Models;
using MarketPlace.DAL.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace MarketPlace.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationContext _context;
        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ProductModel?> FindProductByIdAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
                return null;

            var model = ProductModel.CreateProduct(id,
                product.Title,
                product.TypeName,
                product.Description,
                product.ImageLinks,
                product.Price).Item1;

            return model;
        }

        public async Task<Guid> AddProductAsync(ProductModel product, Guid CategoryId, Guid SellerId)
        {
            var productEntity = new ProductEntity
            {
                Id = product.Id,
                Title = product.Title,
                TypeName = product.TypeName,
                Description = product.Description,
                ImageLinks = product.ImageLinks,
                Price = product.Price,
                CategoryEntity = new CategoryEntity { Id = CategoryId },
                Seller = new SellerEntity { Id = SellerId },
                SellerId = SellerId,
                CategoryId = CategoryId,
                Reviews = new List<ReviewEntity>()
            };

            await _context.AddAsync(productEntity);
            await _context.SaveChangesAsync();

            return productEntity.Id;
        }
        public async Task<Guid> UpdateProductAsync(ProductModel product, Guid CategoryId, Guid SellerId)
        {
            var productEntity = new ProductEntity
            {
                Id = product.Id,
                Title = product.Title,
                TypeName = product.TypeName,
                Description = product.Description,
                ImageLinks = product.ImageLinks,
                Price = product.Price,
                CategoryEntity = new CategoryEntity { Id = CategoryId },
                Seller = new SellerEntity { Id = SellerId },
                SellerId = SellerId,
                CategoryId = CategoryId,
                Reviews = new List<ReviewEntity>()
            };

            _context.Products.Update(productEntity);
            await _context.SaveChangesAsync();

            return product.Id;
        }
        public async Task<Guid> DeleteProductAsync(Guid id)
        {
            _context.Products.Remove(new ProductEntity { Id = id });
            await _context.SaveChangesAsync();

            return id;
        }
        public async Task<List<ProductModel>?> GetProductsByCategoryIdAsync(Guid id)
        {
            var productEntities = await _context.Products.Where(p => p.CategoryId == id).ToListAsync();

            if (productEntities == null)
                return null;

            List<ProductModel> models = new List<ProductModel>();
            foreach (var item in productEntities)
            {
                models.Add(ProductModel.CreateProduct(item.Id, item.Title, item.TypeName, item.Description, item.ImageLinks, item.Price).Item1);
            }

            return models;
        }
        public async Task<List<ProductModel>?>GetProductsBySellerIdAsync(Guid sellerId)
        {
            var seller = await _context.Sellers.Include(x => x.Products)
                                               .FirstOrDefaultAsync(x => x.Id == sellerId);

            if (seller == null || seller.Products.IsNullOrEmpty())
                return null;

            var models = new List<ProductModel>();
            foreach (var item in seller.Products)
                models.Add(ProductModel.CreateProduct(item.Id, item.Title, item.TypeName, item.Description,
                                                      item.ImageLinks, item.Price).Item1);

            return models;
        }
    }
}
using MarketPlace.Core.Models;
using MarketPlace.DAL.Enities;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.DAL.Repositories
{
    public class ProductRepository
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

        public async Task<Guid> AddProductAsync(ProductModel product, Guid sellerId, Guid categoryId)
        {
            var productEntity = new ProductEntity
            {
                Id = product.Id,
                Title = product.Title,
                TypeName = product.TypeName,
                Description = product.Description,
                ImageLinks = product.ImageLinks,
                Price = product.Price,
                SellerId = sellerId,
                CategoryId = categoryId,
            };

            await _context.AddAsync(productEntity);
            await _context.SaveChangesAsync();

            return productEntity.Id;
        }
        public async Task<Guid>UpdateProductAsync(ProductModel product, Guid SellerId ,Guid categoryId)
        {
            var productEntity = new ProductEntity
            {
                Id = product.Id,
                Title = product.Title,
                TypeName = product.TypeName,
                Description = product.Description,
                ImageLinks = product.ImageLinks,
                Price = product.Price,
                SellerId = SellerId,
                CategoryId = categoryId,
            };
            
            _context.Products.Update(productEntity);
            await _context.SaveChangesAsync();

            return product.Id;
        }
        public async Task<Guid>DeleteProductAsync(Guid id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product.Id;
        }
    }
}
using MarketPlace.Core.Interfaces.Repositories;
using MarketPlace.Core.Models;
using MarketPlace.DAL.Enities;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.DAL.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private ApplicationContext _context;
        public ReviewRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<List<ReviewModel>> GetReviewsByProductIdAsync(Guid productId)
        {
            List<ReviewModel> models = new List<ReviewModel>();

            var product = await _context.Products.Include(x => x.Reviews).FirstOrDefaultAsync();

            if (product == null)
                return models;

            foreach (var item in product.Reviews)
                models.Add(ReviewModel.CreateReview(item.Id, item.Username, item.Text,
                    item.Rating, item.DateOfCreate).Item1);

            return models;
        }
        public async Task<ReviewModel?> GetReviewByIdAsync(Guid id)
        {
            var entity = await _context.Reviews.FindAsync(id);

            if (entity == null)
                return null;

            var model = ReviewModel.CreateReview(id, entity.Username, entity.Text, entity.Rating, entity.DateOfCreate).Item1;

            return model;
        }
        public async Task<Guid> AddReviewAsync(ReviewModel review, Guid productId)
        {
            var entity = new ReviewEntity
            {
                Id = review.Id,
                Username = review.Username,
                Text = review.Text,
                Rating = review.Rating,
                DateOfCreate = review.DateOfCreate,
                Product = new ProductEntity { Id = productId },
                ProductId = productId
            };

            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();

            return review.Id;
        }
        public async Task<Guid> UpdateReviewAsync(ReviewModel review, Guid productId)
        {
            var entity = new ReviewEntity
            {
                Id = review.Id,
                Username = review.Username,
                Text = review.Text,
                Rating = review.Rating,
                DateOfCreate = review.DateOfCreate,
                Product = new ProductEntity { Id = productId },
                ProductId = productId
            };

            _context.Update(entity);
            await _context.SaveChangesAsync();

            return review.Id;
        }
        public async Task<Guid> DeleteReviewAsync(Guid reviewId)
        {
            _context.Reviews.Remove(new ReviewEntity { Id = reviewId });
            await _context.SaveChangesAsync();

            return reviewId;
        }
    }
}
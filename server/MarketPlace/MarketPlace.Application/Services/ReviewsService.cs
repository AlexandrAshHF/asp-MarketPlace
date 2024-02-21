using MarketPlace.Core.Interfaces.DataIntefaces;
using MarketPlace.Core.Interfaces.Repositories;
using MarketPlace.Core.Models;
using Microsoft.IdentityModel.Tokens;

namespace MarketPlace.Application.Services
{
    public class ReviewsService : IReviewsService
    {
        private IReviewRepository _reviewRepository;
        public ReviewsService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public async Task<(Guid, string)> EntryReviewAsync(Guid? id, string um, string text, double rating, Guid productId)
        {
            var modelId = id ?? Guid.NewGuid();

            var model = ReviewModel.CreateReview(modelId, um, text, rating, DateTime.Now);

            if (!model.Item2.IsNullOrEmpty())
                return (new Guid(), model.Item2.ToString());

            if (await _reviewRepository.GetReviewByIdAsync(modelId) == null)
                _ = await _reviewRepository.AddReviewAsync(model.Item1, productId);
            else
                _ = await _reviewRepository.UpdateReviewAsync(model.Item1, productId);

            return (modelId, string.Empty);
        }
        public async Task<Guid> DeleteReviewAsync(Guid reviewId)
        {
            return await _reviewRepository.DeleteReviewAsync(reviewId);
        }
        public async Task<ReviewModel?> GetReviewByIdAsync(Guid id)
        {
            return await _reviewRepository.GetReviewByIdAsync(id);
        }
        public async Task<List<ReviewModel>> GetReviewsByProductIdAsync(Guid productId)
        {
            return await _reviewRepository.GetReviewsByProductIdAsync(productId);
        }
    }
}
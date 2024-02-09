using MarketPlace.Core.Models;

namespace MarketPlace.Core.Interfaces.Repositories
{
    public interface IReviewRepository
    {
        Task<Guid> AddReviewAsync(ReviewModel review, Guid productId);
        Task<Guid> DeleteReviewAsync(Guid reviewId);
        Task<ReviewModel?> GetReviewByIdAsync(Guid id);
        Task<List<ReviewModel>> GetReviewsByProductIdAsync(Guid productId);
        Task<Guid> UpdateReviewAsync(ReviewModel review, Guid productId);
    }
}
using MarketPlace.Core.Models;

namespace MarketPlace.Core.Interfaces.DataIntefaces
{
    public interface IReviewsService
    {
        Task<Guid> DeleteReviewAsync(Guid reviewId);
        Task<(Guid, string)> EntryReviewAsync(Guid? id, string um, string text, double rating, Guid productId);
        Task<ReviewModel?> GetReviewByIdAsync(Guid id);
        Task<List<ReviewModel>> GetReviewsByProductIdAsync(Guid productId);
    }
}
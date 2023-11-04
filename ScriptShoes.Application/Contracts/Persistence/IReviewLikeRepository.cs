using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Contracts.Persistence;

public interface IReviewLikeRepository : IGenericRepository<ReviewLike>
{
    public Task<ReviewLike?> GetByReviewIdAndUserId(int reviewId, int userId);
    public Task<ReviewLike?> GetByReviewIdAndUserId(int reviewId, string localUserId);
    public Task<IEnumerable<int>> GetLikedReviews(int shoeId, int userId);
    public Task<IEnumerable<int>> GetLikedReviews(int shoeId, string localUserId);
}
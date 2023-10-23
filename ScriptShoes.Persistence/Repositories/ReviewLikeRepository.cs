using Microsoft.EntityFrameworkCore;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Persistence.Database;

namespace ScriptShoes.Persistence.Repositories;

public class ReviewLikeRepository : GenericRepository<ReviewLike>, IReviewLikeRepository
{
    public ReviewLikeRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<ReviewLike?> GetByReviewIdAndUserId(int reviewId, int userId)
    {
        var reviewLike =
            await _context.ReviewsLikes.FirstOrDefaultAsync(x => x.ReviewId == reviewId && x.UserId == userId);
        return reviewLike;
    }

    public async Task<ReviewLike?> GetByReviewIdAndUserId(int reviewId, string localUserId)
    {
        var reviewLike =
            await _context.ReviewsLikes.FirstOrDefaultAsync(x => x.ReviewId == reviewId && x.LocalId == localUserId);
        return reviewLike;
    }

    public IEnumerable<int> GetLikedReviews(int shoeId, int userId)
    {
        var likedReviews = _context.ReviewsLikes.Where(x => x.UserId == userId && x.ShoeId == shoeId).Select(x => x.ReviewId).ToList();
        return likedReviews;
    }

    public IEnumerable<int> GetLikedReviews(int shoeId, string localUserId)
    {
        var likedReviews = _context.ReviewsLikes.Where(x => x.LocalId == localUserId && x.ShoeId == shoeId).Select(x => x.ReviewId).ToList();
        return likedReviews;
        
    }
}
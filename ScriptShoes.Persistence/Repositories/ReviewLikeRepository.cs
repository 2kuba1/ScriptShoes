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
}
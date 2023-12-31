﻿using Microsoft.EntityFrameworkCore;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Infrastructure.Database;

namespace ScriptShoes.Infrastructure.Repositories;

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

    public async Task<IEnumerable<int>> GetLikedReviews(int shoeId, int userId)
    {
        var likedReviews = await _context.ReviewsLikes.Where(x => x.UserId == userId && x.ShoeId == shoeId).Select(x => x.ReviewId).ToListAsync();
        return likedReviews;
    }

    public async Task<IEnumerable<int>> GetLikedReviews(int shoeId, string localUserId)
    {
        var likedReviews = await _context.ReviewsLikes.Where(x => x.LocalId == localUserId && x.ShoeId == shoeId).Select(x => x.ReviewId).ToListAsync();
        return likedReviews;
        
    }
}
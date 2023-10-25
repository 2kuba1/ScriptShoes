using Mapster;
using Microsoft.EntityFrameworkCore;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Models;
using ScriptShoes.Application.Models.Review;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Persistence.Database;

namespace ScriptShoes.Persistence.Repositories;

public class ReviewRepository : GenericRepository<Review>, IReviewRepository
{
    public ReviewRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<bool> DoesUserHaveReviewForShoe(int userId, int shoeId)
    {
        var review = await _context.Reviews.AnyAsync(x => x.UserId == userId && x.ShoeId == shoeId);
        return review;
    }

    public List<Review> GetShoeReviews(int shoeId)
    {
        var reviews = _context.Reviews.Where(x => x.ShoeId == shoeId).ToList();
        return reviews;
    }
    
    public PagedResult<GetShoeReviewsDto> GetPagedShoeReviews(int shoeId, int pageNumber, int pageSize)
    {
        var baseQuery = _context.Reviews.Where(x => x.ShoeId == shoeId).OrderByDescending(x => x.Id);

        var reviews = baseQuery.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();

        var totalItemsCount = reviews.Count;

        var mappedValues = reviews.Adapt<List<GetShoeReviewsDto>>();

        var pagedReviews =
            new PagedResult<GetShoeReviewsDto>(mappedValues, totalItemsCount, pageSize, pageNumber);
        return pagedReviews;
    }
}
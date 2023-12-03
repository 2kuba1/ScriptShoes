using Microsoft.EntityFrameworkCore;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Infrastructure.Database;

namespace ScriptShoes.Infrastructure.Repositories;

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

    public async Task<List<Review>> GetShoeReviews(int shoeId)
    {
        var reviews = await _context.Reviews.Where(x => x.ShoeId == shoeId).ToListAsync();
        return reviews;
    }

    public async Task<List<Review>> GetPagedShoeReviews(int shoeId, int pageNumber, int pageSize)
    {
        var baseQuery = _context.Reviews.Where(x => x.ShoeId == shoeId).OrderByDescending(x => x.Id);

        var reviews = await baseQuery.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();
       
        return reviews;
    }

    public async Task<List<float>> GetShoRates(int shoeId)
    {
        var shoeRates = await _context.Reviews.Where(x => x.ShoeId == shoeId).Select(x => x.ShoeRate).ToListAsync();
        return shoeRates;
    }
}
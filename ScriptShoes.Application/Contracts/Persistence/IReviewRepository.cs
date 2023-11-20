using ScriptShoes.Application.Models;
using ScriptShoes.Application.Models.Review;
using ScriptShoes.Domain;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Contracts.Persistence;

public interface IReviewRepository : IGenericRepository<Review>
{
    public Task<bool> DoesUserHaveReviewForShoe(int userId, int shoeId);
    public Task<List<Review>> GetShoeReviews(int shoeId);
    public Task<List<Review>> GetPagedShoeReviews(int shoeId, int pageNumber, int pageSize);
    public Task<GetShoeRatesDto> GetShoRates(int shoeId);
}
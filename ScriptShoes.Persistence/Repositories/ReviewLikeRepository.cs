using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Persistence.Database;

namespace ScriptShoes.Persistence.Repositories;

public class ReviewLikeRepository : GenericRepository<ReviewLike>, IReviewLikeRepository
{
    public ReviewLikeRepository(AppDbContext context) : base(context)
    {
    }
}
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Persistence.Database;
using ScriptShoes.Persistence.Repositories;

namespace ScriptShoes.Persistence;

public class ReviewRepository : GenericRepository<Review>, IReviewRepository
{
    public ReviewRepository(AppDbContext context) : base(context)
    {
    }
}
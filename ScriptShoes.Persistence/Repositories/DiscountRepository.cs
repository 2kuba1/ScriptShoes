using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Persistence.Database;

namespace ScriptShoes.Persistence.Repositories;

public class DiscountRepository : GenericRepository<Discount>, IDiscountRepository
{
    public DiscountRepository(AppDbContext context) : base(context)
    {
    }
}
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Persistence.Database;
using ScriptShoes.Persistence.Repositories;

namespace ScriptShoes.Persistence;

public class CartRepository : GenericRepository<Cart>, ICartRepository
{
    public CartRepository(AppDbContext context) : base(context)
    {
    }
}
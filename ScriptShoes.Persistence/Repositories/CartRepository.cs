using Microsoft.EntityFrameworkCore;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Persistence.Database;

namespace ScriptShoes.Persistence.Repositories;

public class CartRepository : GenericRepository<Cart>, ICartRepository
{
    public CartRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Cart?> GetByUserIdAndItemId(int userId, int shoeId)
    {
        var cart = await _context.Carts.FirstOrDefaultAsync(x => x.UserId == userId && x.ShoeId == shoeId);
        return cart;
    }
}
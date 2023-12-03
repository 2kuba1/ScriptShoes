using Microsoft.EntityFrameworkCore;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Infrastructure.Database;

namespace ScriptShoes.Infrastructure.Repositories;

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

    public async Task<List<Cart>> GetCartByUserId(int userId)
    {
        var itemsFromCart = await _context.Carts.Where(x => x.UserId == userId).ToListAsync();
        return itemsFromCart;
    }
}
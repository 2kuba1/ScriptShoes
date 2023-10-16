using Mapster;
using Microsoft.EntityFrameworkCore;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Models.Cart;
using ScriptShoes.Application.Models.Shoe;
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

    public List<GetCartDto> GetShoesFromCart(int userId)
    {
        var itemsFromCart = _context.Carts.Where(x => x.UserId == userId)
            .Select(s => s.ShoeId).ToList();

        var items = new List<Shoe>();

        itemsFromCart.ForEach(x => items.Add(_context.Shoes.FirstOrDefault(s => s.Id == x)!));

        var dto = items.Adapt<List<GetCartDto>>();
        return dto;
    }
}
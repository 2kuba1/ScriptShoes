using Microsoft.EntityFrameworkCore;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Models.Cart;
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
        var itemsFromCart = _context.Carts.Where(x => x.UserId == userId).ToList();

        var items = new List<GetCartDto>();

        itemsFromCart.ForEach(x =>
        {
            var shoe = _context.Shoes.FirstOrDefault(s => s.Id == x.ShoeId)!;

            items.Add(new GetCartDto()
            {
                Brand = shoe.Brand,
                ShoeName = shoe.ShoeName,
                CurrentPrice = shoe.CurrentPrice,
                ThumbnailImage = shoe.ThumbnailImage,
                Id = shoe.Id,
                ItemCount = x.ItemCount
            });
        });

        return items;
    }
}
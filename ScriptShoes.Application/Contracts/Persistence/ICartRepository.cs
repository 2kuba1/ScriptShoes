using ScriptShoes.Application.Models.Cart;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Contracts.Persistence;

public interface ICartRepository : IGenericRepository<Cart>
{
    public Task<Cart?> GetByUserIdAndItemId(int userId, int shoeId);
    public List<GetCartDto>  GetShoesFromCart(int userId);
}
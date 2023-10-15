using ScriptShoes.Domain;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Contracts.Persistence;

public interface ICartRepository : IGenericRepository<Cart>
{
    public Task<Cart?> GetByUserIdAndItemId(int userId, int shoeId);
}
using ScriptShoes.Application.Models.Discount;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Contracts.Persistence;

public interface IDiscountRepository : IGenericRepository<Discount>
{
    Task CreateDiscount(CreateDiscountDto dto);
    Task DeleteDiscount(Discount discount);
}
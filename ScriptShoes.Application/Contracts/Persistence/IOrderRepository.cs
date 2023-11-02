using ScriptShoes.Application.Models.Cart;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Contracts.Persistence;

public interface IOrderRepository : IGenericRepository<Order>
{
    Task<Order?> GetOrderBySessionId(string sessionId);
    Task RemoveExpiredOrders(List<Order> expiredOrders);
    List<Order> GetExpiredOrders();
    Task RemoveOrder(string sessionId);
}
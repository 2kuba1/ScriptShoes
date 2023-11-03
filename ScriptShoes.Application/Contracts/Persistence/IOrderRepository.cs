using ScriptShoes.Application.Models;
using ScriptShoes.Application.Models.Cart;
using ScriptShoes.Application.Models.Order;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Contracts.Persistence;

public interface IOrderRepository : IGenericRepository<Order>
{
    Task<Order?> GetOrderBySessionId(string sessionId);
    Task RemoveExpiredOrders(List<Order> expiredOrders);
    List<Order> GetExpiredOrders();
    Task RemoveOrder(string sessionId);
    Task<PagedResult<UserOrdersDto>> GetUserOrders(int userId, int pageSize, int pageNumber);
}
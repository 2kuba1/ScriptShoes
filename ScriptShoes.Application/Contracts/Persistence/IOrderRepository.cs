using ScriptShoes.Application.Models;
using ScriptShoes.Application.Models.Cart;
using ScriptShoes.Application.Models.Order;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Contracts.Persistence;

public interface IOrderRepository : IGenericRepository<Order>
{
    Task<Order?> GetOrderBySessionId(string sessionId);
    Task RemoveExpiredOrders(IEnumerable<Order> expiredOrders);
    Task<List<Order>> GetExpiredOrders();
    Task RemoveOrder(string sessionId);
    Task<List<Order>> GetUserOrders(int userId, int pageSize, int pageNumber);
    Task<PagedResult<GetOrdersAsAdminDto>> GetPagedOrders(int pageSize, int pageNumber);
}
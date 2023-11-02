using Microsoft.EntityFrameworkCore;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Persistence.Database;

namespace ScriptShoes.Persistence.Repositories;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Order?> GetOrderBySessionId(string sessionId)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(x => x.SessionId == sessionId);
        return order;
    }

    public async Task RemoveExpiredOrders(List<Order> expiredOrders)
    {
        _context.Orders.RemoveRange(expiredOrders);
        await _context.SaveChangesAsync();
    }

    public List<Order> GetExpiredOrders()
    {
        var expiredOrders = _context.Orders
            .Where(x => x.SessionExpirationDateTime < DateTime.UtcNow && x.IsConfirmed == false)
            .ToList();
        return expiredOrders;
    }

    public async Task RemoveOrder(string sessionId)
    {
        var orders = _context.Orders.Where(x => x.SessionId == sessionId).ToList();
        
        _context.Orders.RemoveRange(orders);
        await _context.SaveChangesAsync();

        var orderAddress = await _context.OrdersAddresses.FirstOrDefaultAsync(x => x.OrderSessionId == sessionId);

        if (orderAddress is not null)
        {
            _context.OrdersAddresses.Remove(orderAddress);
            await _context.SaveChangesAsync();
        }
    }

    public List<Order> GetOrdersBySessionId(string sessionId)
    {
        var orders = _context.Orders.Where(x => x.SessionId == sessionId).ToList();
        return orders;
    }
}
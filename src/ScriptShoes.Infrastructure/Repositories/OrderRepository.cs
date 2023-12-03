using Microsoft.EntityFrameworkCore;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Infrastructure.Database;

namespace ScriptShoes.Infrastructure.Repositories;

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

    public async Task RemoveExpiredOrders(IEnumerable<Order> expiredOrders)
    {
        _context.Orders.RemoveRange(expiredOrders);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Order>> GetExpiredOrders()
    {
        var expiredOrders = await _context.Orders
            .Where(x => x.SessionExpirationDateTime < DateTime.UtcNow && x.IsConfirmed == false)
            .ToListAsync();
        return expiredOrders;
    }

    public async Task RemoveOrder(string sessionId)
    {
        var orders = await _context.Orders.Where(x => x.SessionId == sessionId).ToListAsync();

        _context.Orders.RemoveRange(orders);
        await _context.SaveChangesAsync();

        var orderAddress = await _context.OrdersAddresses.FirstOrDefaultAsync(x => x.OrderSessionId == sessionId);

        if (orderAddress is not null)
        {
            _context.OrdersAddresses.Remove(orderAddress);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<List<Order>> GetUserOrders(int userId, int pageSize, int pageNumber)
    {
        var baseQuery = _context.Orders.Include(x => x.Shoe).Where(x => x.UserId == userId)
            .OrderByDescending(x => x.Id);

        var orders = await baseQuery.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();
        
        return orders;
    }

    public async Task<List<Order>> GetPagedOrders(int pageSize, int pageNumber)
    {
        var baseQuery = _context.Orders
            .Include(x => x.Shoe)
            .Include(x => x.OrderAddress)
            .OrderByDescending(x => x.Id)
            .Where(x => x.IsConfirmed == true);

        var orders = await baseQuery.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();
        
        return orders;
    }

    public async Task<List<Order>> GetOrdersBySessionId(string sessionId)
    {
        var orders = await _context.Orders.Where(x => x.SessionId == sessionId).ToListAsync();
        return orders;
    }
}
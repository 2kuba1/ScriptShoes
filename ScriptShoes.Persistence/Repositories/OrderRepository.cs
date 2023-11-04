using Mapster;
using Microsoft.EntityFrameworkCore;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Models;
using ScriptShoes.Application.Models.Order;
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

    public async Task<PagedResult<UserOrdersDto>> GetUserOrders(int userId, int pageSize, int pageNumber)
    {
        var baseQuery = _context.Orders.Include(x => x.Shoe).Where(x => x.UserId == userId)
            .OrderByDescending(x => x.Id);

        var orders = await baseQuery.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();

        var totalItemsCount = orders.Count;

        var userOrders = new List<UserOrdersDto>();

        foreach (var order in orders)
        {
            var address = await _context.OrdersAddresses.FirstOrDefaultAsync(x => x.OrderSessionId == order.SessionId);

            if (address is null)
                continue;


            TypeAdapterConfig config = new();

            config.NewConfig<Order, UserOrdersDto>()
                .Map(dest => dest.Brand, src => src.Shoe.Brand)
                .Map(dest => dest.ShoeName, src => src.Shoe.ShoeName);

            var newOrder = order.Adapt<UserOrdersDto>(config);
            userOrders.Add(newOrder);
        }


        return new PagedResult<UserOrdersDto>(userOrders, totalItemsCount, pageSize, pageNumber);
    }

    public async  Task<List<Order>> GetOrdersBySessionId(string sessionId)
    {
        var orders = await _context.Orders.Where(x => x.SessionId == sessionId).ToListAsync();
        return orders;
    }
}
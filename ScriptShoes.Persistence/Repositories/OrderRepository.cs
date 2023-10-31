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

    public async Task RemoveExpiredOrders()
    {
        var expiredOrders = _context.Orders.Where(x => x.SessionExpirationDateTime > DateTime.UtcNow && !x.IsConfirmed)
            .ToList();

        foreach (var order in expiredOrders)
        {
            var shoe = await _context.Shoes.FirstOrDefaultAsync(x => x.Id == order.ShoeId);

            if (shoe is null)
                continue;

            shoe.Quantity += order.Quantity;
            _context.Shoes.Update(shoe);
            await _context.SaveChangesAsync();
        }

        _context.Orders.RemoveRange(expiredOrders);
        await _context.SaveChangesAsync();
    }
}
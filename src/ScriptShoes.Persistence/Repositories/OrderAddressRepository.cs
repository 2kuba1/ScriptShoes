using Microsoft.EntityFrameworkCore;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Persistence.Database;

namespace ScriptShoes.Persistence.Repositories;

public class OrderAddressRepository : GenericRepository<OrderAddress>, IOrderAddressRepository
{
    public OrderAddressRepository(AppDbContext context) : base(context)
    {
    }

    public async Task RemoveExpiredOrdersAddresses(List<Order> expiredOrders)
    {
        foreach (var expiredOrder in expiredOrders)
        {
            var expireOrderAddresses =
                await _context.OrdersAddresses.FirstOrDefaultAsync(x => x.OrderSessionId == expiredOrder.SessionId);
            if (expireOrderAddresses != null) _context.OrdersAddresses.Remove(expireOrderAddresses);
        }
    }

    public async Task<OrderAddress?> GetOrderAddressBySessionId(string sessionId)
    {
        var address = await _context.OrdersAddresses.FirstOrDefaultAsync(x => x.OrderSessionId == sessionId);
        return address;
    }
}
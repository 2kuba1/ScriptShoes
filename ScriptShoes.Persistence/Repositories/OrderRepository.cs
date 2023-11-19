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

    public async Task<PagedResult<GetOrdersAsAdminDto>> GetPagedOrders(int pageSize, int pageNumber)
    {
        var baseQuery = _context.Orders
            .Include(x => x.Shoe)
            .Include(x => x.OrderAddress)
            .OrderByDescending(x => x.Id)
            .Where(x => x.IsConfirmed == true);

        var orders = await baseQuery.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();

        var totalItemsCount = orders.Count;

        TypeAdapterConfig config = new();

        config.NewConfig<Order, GetOrdersAsAdminDto>()
            .Map(dest => dest.GetOrdersDto.Brand, src => src.Shoe.Brand)
            .Map(dest => dest.GetOrdersDto.ShoeName, src => src.Shoe.ShoeName)
            .Map(dest => dest.GetOrdersDto.CurrentPrice, src => src.Shoe.CurrentPrice)
            .Map(dest => dest.GetOrdersDto.ThumbnailImage, src => src.Shoe.ThumbnailImage)
            .Map(dest => dest.GetOrdersDto.Id, src => src.Id)
            .Map(dest => dest.GetOrdersDto.Quantity, src => src.Quantity)
            .Map(dest => dest.GetOrdersDto.ShoeId, src => src.ShoeId)
            .Map(dest => dest.City, src => src.OrderAddress.City)
            .Map(dest => dest.GetOrdersDto.OrderAddressId, src => src.OrderAddress.Id)
            .Map(dest => dest.Street, src => src.OrderAddress.Street)
            .Map(dest => dest.PostalCode, src => src.OrderAddress.PostalCode);

        var mappedValues = orders.Adapt<List<GetOrdersAsAdminDto>>(config);

        return new PagedResult<GetOrdersAsAdminDto>(mappedValues, totalItemsCount, pageSize, pageNumber);
    }

    public async Task<List<Order>> GetOrdersBySessionId(string sessionId)
    {
        var orders = await _context.Orders.Where(x => x.SessionId == sessionId).ToListAsync();
        return orders;
    }
}
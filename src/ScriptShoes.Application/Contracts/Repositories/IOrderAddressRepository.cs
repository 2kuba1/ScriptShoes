using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Contracts.Persistence;

public interface IOrderAddressRepository : IGenericRepository<OrderAddress>
{
    Task RemoveExpiredOrdersAddresses(List<Order> expiredOrders);
    Task<OrderAddress?> GetOrderAddressBySessionId(string sessionId);
}
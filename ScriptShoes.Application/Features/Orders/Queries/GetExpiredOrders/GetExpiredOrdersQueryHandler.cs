using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Features.Orders.Queries.GetExpiredOrders;

public class GetExpiredOrdersQueryHandler : IRequestHandler<GetExpiredOrdersQuery, List<Order>>
{
    private readonly IOrderRepository _orderRepository;

    public GetExpiredOrdersQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public async Task<List<Order>> Handle(GetExpiredOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = _orderRepository.GetExpiredOrders();
        return orders;
    }
}
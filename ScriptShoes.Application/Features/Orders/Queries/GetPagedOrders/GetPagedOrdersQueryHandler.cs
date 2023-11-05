using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Models;
using ScriptShoes.Application.Models.Order;

namespace ScriptShoes.Application.Features.Orders.Queries.GetPagedOrders;

public class GetPagedOrdersQueryHandler : IRequestHandler<GetPagedOrdersQuery, PagedResult<GetOrdersAsAdminDto>>
{
    private readonly IOrderRepository _orderRepository;

    public GetPagedOrdersQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public async Task<PagedResult<GetOrdersAsAdminDto>> Handle(GetPagedOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetPagedOrders(request.PageSize, request.PageNumber);
        return orders;
    }
}
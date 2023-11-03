using MediatR;
using ScriptShoes.Application.Common;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Models;
using ScriptShoes.Application.Models.Order;

namespace ScriptShoes.Application.Features.Orders.Queries.GetUserOrders;

public class GetUserOrdersQueryHandler : IRequestHandler<GetUserOrdersQuery, PagedResult<UserOrdersDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IOrderRepository _orderRepository;

    public GetUserOrdersQueryHandler(IUserRepository userRepository, IOrderRepository orderRepository)
    {
        _userRepository = userRepository;
        _orderRepository = orderRepository;
    }
    
    public async Task<PagedResult<UserOrdersDto>> Handle(GetUserOrdersQuery request, CancellationToken cancellationToken)
    {
        var user = await GetUserByHttpContextId.Get(_userRepository);

        var orders = await _orderRepository.GetUserOrders(user.Id, request.PageSize, request.PageNumber);

        return orders;
    }
}
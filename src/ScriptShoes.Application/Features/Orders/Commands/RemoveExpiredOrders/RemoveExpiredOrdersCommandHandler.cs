using MediatR;
using ScriptShoes.Application.Contracts.Persistence;

namespace ScriptShoes.Application.Features.Orders.Commands.RemoveExpiredOrders;

public class RemoveExpiredOrdersCommandHandler : IRequestHandler<RemoveExpiredOrdersCommand, Unit>
{
    private readonly IOrderRepository _orderRepository;

    public RemoveExpiredOrdersCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }
    
    public async Task<Unit> Handle(RemoveExpiredOrdersCommand request, CancellationToken cancellationToken)
    {
        await _orderRepository.RemoveExpiredOrders(request.ExpiredOrders);
        return Unit.Value;
    }
}
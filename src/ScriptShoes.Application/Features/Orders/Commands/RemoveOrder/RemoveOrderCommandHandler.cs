using MediatR;
using ScriptShoes.Application.Contracts.Persistence;

namespace ScriptShoes.Application.Features.Orders.Commands.RemoveOrder;

public class RemoveOrderCommandHandler : IRequestHandler<RemoveOrderCommand, Unit>
{
    private readonly IOrderRepository _orderRepository;

    public RemoveOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Unit> Handle(RemoveOrderCommand request, CancellationToken cancellationToken)
    {
        await _orderRepository.RemoveOrder(request.OrderSessionId);
        return Unit.Value;
    }
}
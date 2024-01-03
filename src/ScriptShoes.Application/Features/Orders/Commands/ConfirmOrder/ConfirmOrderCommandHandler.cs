using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Contracts.Services;
using ScriptShoes.Application.Exceptions;

namespace ScriptShoes.Application.Features.Orders.Commands.ConfirmOrder;

public class ConfirmOrderCommandHandler : IRequestHandler<ConfirmOrderCommand, Unit>
{
    private readonly IPaymentsService _paymentsService;
    private readonly IOrderRepository _orderRepository;
    private readonly IShoeRepository _shoeRepository;

    public ConfirmOrderCommandHandler(IPaymentsService paymentsService, IOrderRepository orderRepository,
        IShoeRepository shoeRepository)
    {
        _paymentsService = paymentsService;
        _orderRepository = orderRepository;
        _shoeRepository = shoeRepository;
    }

    public async Task<Unit> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetOrderBySessionId(request.SessionId);

        if (order is null)
            throw new NotFoundException("Order not found");

        var shoe = await _shoeRepository.GetByIdAsync(order.ShoeId);

        if (shoe is null)
            throw new NotFoundException("Shoe not found");

        await _paymentsService.ConfirmOrder(request.SessionId);
        
        return Unit.Value;
    }
}
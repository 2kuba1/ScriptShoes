using MediatR;
using ScriptShoes.Application.Contracts.Infrastructure.StripePayments;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Exceptions;

namespace ScriptShoes.Application.Features.Orders.Commands.ConfirmOrder;

public class ConfirmOrderCommandHandler : IRequestHandler<ConfirmOrderCommand, Unit>
{
    private readonly IStripePayments _stripePayments;
    private readonly IOrderRepository _orderRepository;
    private readonly IShoeRepository _shoeRepository;

    public ConfirmOrderCommandHandler(IStripePayments stripePayments, IOrderRepository orderRepository,
        IShoeRepository shoeRepository)
    {
        _stripePayments = stripePayments;
        _orderRepository = orderRepository;
        _shoeRepository = shoeRepository;
    }

    public async Task<Unit> Handle(ConfirmOrderCommand request, CancellationToken cancellationToken)
    {
        await _stripePayments.ConfirmOrder(request.SessionId);
        var order = await _orderRepository.GetOrderBySessionId(request.SessionId);

        if (order is null)
            throw new NotFoundException("Order not found");

        var shoe = await _shoeRepository.GetByIdAsync(order.ShoeId);

        if (shoe is null)
            throw new NotFoundException("Shoe not found");

        await _shoeRepository.UpdateAsync(shoe);

        return Unit.Value;
    }
}
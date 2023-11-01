using MediatR;
using ScriptShoes.Application.Contracts.Persistence;

namespace ScriptShoes.Application.Features.Orders.Commands.RemoveExpiredOrdersAddresses;

public class RemoveExpiredOrdersAddressesCommandHandler : IRequestHandler<RemoveExpiredOrdersAddressesCommand, Unit>
{
    private readonly IOrderAddressRepository _orderAddressRepository;

    public RemoveExpiredOrdersAddressesCommandHandler(IOrderAddressRepository orderAddressRepository)
    {
        _orderAddressRepository = orderAddressRepository;
    }
    
    public async Task<Unit> Handle(RemoveExpiredOrdersAddressesCommand request, CancellationToken cancellationToken)
    {
        await _orderAddressRepository.RemoveExpiredOrdersAddresses(request.ExpiredOrders);
        return Unit.Value;
    }
}
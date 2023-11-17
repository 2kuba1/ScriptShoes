using MediatR;
using ScriptShoes.Application.Contracts.Persistence;

namespace ScriptShoes.Application.Features.Discount.Commands.RemoveExpiredDiscounts;

public class RemoveExpiredDiscountsCommandHandler : IRequestHandler<RemoveExpiredDiscountsCommand, Unit>
{
    private readonly IDiscountRepository _discountRepository;

    public RemoveExpiredDiscountsCommandHandler(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;
    }
    
    public async Task<Unit> Handle(RemoveExpiredDiscountsCommand request, CancellationToken cancellationToken)
    {
        await _discountRepository.RemoveExpiredDiscounts(request.Discounts);
        return Unit.Value;
    }
}
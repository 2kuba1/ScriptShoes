using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Exceptions;

namespace ScriptShoes.Application.Features.Discount.Commands.RemoveDiscount;

public class RemoveDiscountCommandHandler : IRequestHandler<RemoveDiscountCommand, Unit>
{
    private readonly IDiscountRepository _discountRepository;

    public RemoveDiscountCommandHandler(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;
    }

    public async Task<Unit> Handle(RemoveDiscountCommand request, CancellationToken cancellationToken)
    {
        var discount = await _discountRepository.GetByIdAsync(request.DiscountId);
        if (discount is null)
            throw new NotFoundException("Discount not found");
        await _discountRepository.DeleteDiscount(discount);
        return Unit.Value;
    }
}
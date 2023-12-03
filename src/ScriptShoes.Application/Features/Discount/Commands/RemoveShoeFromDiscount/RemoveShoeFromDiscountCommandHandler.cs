using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Exceptions;

namespace ScriptShoes.Application.Features.Discount.Commands.RemoveShoeFromDiscount;

public class RemoveShoeFromDiscountCommandHandler : IRequestHandler<RemoveShoeFromDiscountCommand, Unit>
{
    private readonly IDiscountRepository _discountRepository;
    private readonly IShoeRepository _shoeRepository;

    public RemoveShoeFromDiscountCommandHandler(IDiscountRepository discountRepository, IShoeRepository shoeRepository)
    {
        _discountRepository = discountRepository;
        _shoeRepository = shoeRepository;
    }

    public async Task<Unit> Handle(RemoveShoeFromDiscountCommand request, CancellationToken cancellationToken)
    {
        var discount = await _discountRepository.GetDiscountByShoeId(request.ShoeId);

        if (discount is null)
            throw new NotFoundException("Discount not found");

        var shoe = await _shoeRepository.GetByIdAsync(request.ShoeId);
        
        if(shoe is null)
            throw new NotFoundException("Shoe not found");
        
        await _discountRepository.RemoveShoeFromDiscount(discount, shoe);

        return Unit.Value;
    }
}
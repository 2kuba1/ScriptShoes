using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Exceptions;

namespace ScriptShoes.Application.Features.Discount.Commands;

public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand, Unit>
{
    private readonly IDiscountRepository _discountRepository;

    public CreateDiscountCommandHandler(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;
    }

    public async Task<Unit> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
    {
        await _discountRepository.CreateDiscount(request.Dto);
        return Unit.Value;
    }
}
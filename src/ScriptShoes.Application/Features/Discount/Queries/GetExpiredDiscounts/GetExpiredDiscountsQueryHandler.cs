using MediatR;
using ScriptShoes.Application.Contracts.Persistence;

namespace ScriptShoes.Application.Features.Discount.Queries.GetExpiredDiscounts;

public class GetExpiredDiscountsQueryHandler : IRequestHandler<GetExpiredDiscountsQuery, List<Domain.Entities.Discount>>
{
    private readonly IDiscountRepository _discountRepository;

    public GetExpiredDiscountsQueryHandler(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;
    }
    
    public async Task<List<Domain.Entities.Discount>> Handle(GetExpiredDiscountsQuery request, CancellationToken cancellationToken)
    {
        var expiredDiscounts = await _discountRepository.GetExpiredDiscounts();
        return expiredDiscounts;
    }
}
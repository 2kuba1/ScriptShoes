using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Models.Review;

namespace ScriptShoes.Application.Features.Review.Queries.GetShoeRates;

public class GetShoeRatesQueryHandler : IRequestHandler<GetShoeRatesQuery, GetShoeRatesDto>
{
    private readonly IReviewRepository _reviewRepository;

    public GetShoeRatesQueryHandler(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }
    
    public async Task<GetShoeRatesDto> Handle(GetShoeRatesQuery request, CancellationToken cancellationToken)
    {
        var rates = await _reviewRepository.GetShoRates(request.ShoeId);
        return rates;
    }
}
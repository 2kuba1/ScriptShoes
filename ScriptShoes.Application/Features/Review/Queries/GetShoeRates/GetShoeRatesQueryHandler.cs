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
        var shoeRates = await _reviewRepository.GetShoRates(request.ShoeId);
        
        var rates = new GetShoeRatesDto();

        foreach (var rate in shoeRates)
        {
            switch (rate)
            {
                case 1:
                    rates.OneStarsCount++;
                    break;
                case 2:
                    rates.TwoStarsCount++;
                    break;
                case 3:
                    rates.ThreeStarsCount++;
                    break;
                case 4:
                    rates.FourStarsCount++;
                    break;
                case 5:
                    rates.FiveStarsCount++;
                    break;
            }
        }

        rates.ShoeId = request.ShoeId;

        return rates;
    }
}
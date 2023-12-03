using Mapster;
using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Exceptions;
using ScriptShoes.Application.Models.Review;

namespace ScriptShoes.Application.Features.Review.Queries.GetShoeReviews;

public class GetShoeReviewsQueryHandler : IRequestHandler<GetShoeReviewsQuery, List<GetShoeReviewsDto>>
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IShoeRepository _shoeRepository;

    public GetShoeReviewsQueryHandler(IReviewRepository reviewRepository, IShoeRepository shoeRepository)
    {
        _reviewRepository = reviewRepository;
        _shoeRepository = shoeRepository;
    }

    public async Task<List<GetShoeReviewsDto>> Handle(GetShoeReviewsQuery request, CancellationToken cancellationToken)
    {
        var shoe = await _shoeRepository.GetByIdAsync(request.ShoeId);

        if (shoe is null)
            throw new NotFoundException("Shoe not found");

        var reviews = await _reviewRepository.GetShoeReviews(request.ShoeId);

        var config = new TypeAdapterConfig();

        config.NewConfig<Domain.Entities.Review, GetShoeReviewsDto>()
            .Map(dest => dest.Username, src => src.Username)
            .Map(dest => dest.Created, src => src.Created);

        var dto = reviews.Adapt<List<GetShoeReviewsDto>>(config);

        return dto;
    }
}
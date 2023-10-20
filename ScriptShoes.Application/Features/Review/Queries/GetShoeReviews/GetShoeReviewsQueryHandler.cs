using Mapster;
using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Models.Review;
using ScriptShoes.Domain.Exceptions;

namespace ScriptShoes.Application.Features.Review.Queries.GetShoeReviews;

public class GetShoeReviewsQueryHandler : IRequestHandler<GetShoeReviewsQuery, List<GetShoeReviewsDto>>
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IShoeRepository _shoeRepository;
    private readonly IUserRepository _userRepository;

    public GetShoeReviewsQueryHandler(IReviewRepository reviewRepository, IShoeRepository shoeRepository,
        IUserRepository userRepository)
    {
        _reviewRepository = reviewRepository;
        _shoeRepository = shoeRepository;
        _userRepository = userRepository;
    }

    public async Task<List<GetShoeReviewsDto>> Handle(GetShoeReviewsQuery request, CancellationToken cancellationToken)
    {
        var shoe = await _shoeRepository.GetByIdAsync(request.ShoeId);

        if (shoe is null)
            throw new NotFoundException("Shoe not found");

        var reviews = _reviewRepository.GetShoeReviews(request.ShoeId);

        var config = new TypeAdapterConfig();

        config.NewConfig<Domain.Entities.Review, GetShoeReviewsDto>()
            .Map(dest => dest.Username, src => src.Username)
            .Map(dest => dest.Created, src => src.Created);

        var dto = reviews.Adapt<List<GetShoeReviewsDto>>(config);

        return dto;
    }
}
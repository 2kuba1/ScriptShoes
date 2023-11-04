using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Models;
using ScriptShoes.Application.Models.Review;

namespace ScriptShoes.Application.Features.Review.Queries.GetPagedReviews;

public class GetPagedReviewsQueryHandler : IRequestHandler<GetPagedReviewsQuery, PagedResult<GetShoeReviewsDto>>
{
    private readonly IReviewRepository _reviewRepository;

    public GetPagedReviewsQueryHandler(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }
    
    public async Task<PagedResult<GetShoeReviewsDto>> Handle(GetPagedReviewsQuery request, CancellationToken cancellationToken)
    {
        var pagedResults = await _reviewRepository.GetPagedShoeReviews(request.ShoeId, request.PageNumber, request.PageSize);
        return pagedResults;
    }
}
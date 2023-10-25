using MediatR;
using ScriptShoes.Application.Models;
using ScriptShoes.Application.Models.Review;

namespace ScriptShoes.Application.Features.Review.Queries.GetPagedReviews;

public record GetPagedReviewsQuery(int ShoeId, int PageNumber, int PageSize) : IRequest<PagedResult<GetShoeReviewsDto>>;
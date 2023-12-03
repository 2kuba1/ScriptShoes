using MediatR;
using ScriptShoes.Application.Models.Review;

namespace ScriptShoes.Application.Features.Review.Queries.GetShoeReviews;

public record GetShoeReviewsQuery(int ShoeId) : IRequest<List<GetShoeReviewsDto>>;
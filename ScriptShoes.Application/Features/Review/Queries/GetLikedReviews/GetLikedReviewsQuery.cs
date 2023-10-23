using MediatR;

namespace ScriptShoes.Application.Features.Review.Queries.GetLikedReviews;

public record GetLikedReviewsQuery(int ShoeId, int? UserId, string? LocalUserId) : IRequest<List<int>>;
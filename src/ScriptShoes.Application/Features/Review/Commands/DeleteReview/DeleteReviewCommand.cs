using MediatR;

namespace ScriptShoes.Application.Features.Review.Commands.DeleteReview;

public record DeleteReviewCommand(int ReviewId) : IRequest<Unit>;
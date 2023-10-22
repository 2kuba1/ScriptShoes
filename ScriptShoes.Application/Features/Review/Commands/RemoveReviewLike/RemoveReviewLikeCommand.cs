using MediatR;
using ScriptShoes.Application.Models.Review;

namespace ScriptShoes.Application.Features.Review.Commands.RemoveReviewLike;

public record RemoveReviewLikeCommand(RemoveReviewLikeDto Dto) : IRequest<Unit>;
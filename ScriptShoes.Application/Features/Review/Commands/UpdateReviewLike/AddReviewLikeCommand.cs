using MediatR;
using ScriptShoes.Application.Models.Review;

namespace ScriptShoes.Application.Features.Review.Commands.UpdateReviewLike;

public record AddReviewLikeCommand(AddReviewLikeDto dto) : IRequest<Unit>;
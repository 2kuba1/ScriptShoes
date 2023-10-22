using MediatR;
using ScriptShoes.Application.Models.Review;

namespace ScriptShoes.Application.Features.Review.Commands.AddReviewLike;

public record AddReviewLikeCommand(AddReviewLikeDto Dto) : IRequest<Unit>;
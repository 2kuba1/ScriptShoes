using MediatR;
using ScriptShoes.Application.Models.Review;

namespace ScriptShoes.Application.Features.Review.Commands;

public record CreateReviewCommand(CreateReviewDto Dto) : IRequest<Unit>;
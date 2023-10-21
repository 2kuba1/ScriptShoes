using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Exceptions;

namespace ScriptShoes.Application.Features.Review.Commands.DeleteReview;

public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, Unit>
{
    private readonly IReviewRepository _reviewRepository;

    public DeleteReviewCommandHandler(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }
    
    public async Task<Unit> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
    {
        var review = await _reviewRepository.GetByIdAsync(request.ReviewId);

        if (review is null)
            throw new NotFoundException("Review not found");

        await _reviewRepository.DeleteAsync(review);
        
        return Unit.Value;
    }
}
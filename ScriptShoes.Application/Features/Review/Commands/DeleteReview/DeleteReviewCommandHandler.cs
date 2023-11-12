using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Exceptions;

namespace ScriptShoes.Application.Features.Review.Commands.DeleteReview;

public class DeleteReviewCommandHandler : IRequestHandler<DeleteReviewCommand, Unit>
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IShoeRepository _shoeRepository;

    public DeleteReviewCommandHandler(IReviewRepository reviewRepository, IShoeRepository shoeRepository)
    {
        _reviewRepository = reviewRepository;
        _shoeRepository = shoeRepository;
    }

    public async Task<Unit> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
    {
        var review = await _reviewRepository.GetByIdAsync(request.ReviewId);

        if (review is null)
            throw new NotFoundException("Review not found");

        var shoe = await _shoeRepository.GetByIdAsync(review.ShoeId);

        if (shoe is null)
            throw new NotFoundException("Shoe not found");

        var numberOfReviews = shoe.NumberOfReviews--;
        shoe.AverageRating = (shoe.AverageRating - review.ShoeRate) / numberOfReviews;

        await _shoeRepository.UpdateAsync(shoe);

        await _reviewRepository.DeleteAsync(review);

        return Unit.Value;
    }
}
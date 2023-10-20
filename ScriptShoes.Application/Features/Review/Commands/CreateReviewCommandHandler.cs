using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Exceptions;

namespace ScriptShoes.Application.Features.Review.Commands;

public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, Unit>
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IUserRepository _userRepository;
    private readonly IShoeRepository _shoeRepository;

    public CreateReviewCommandHandler(IReviewRepository reviewRepository, IUserRepository userRepository,
        IShoeRepository shoeRepository)
    {
        _reviewRepository = reviewRepository;
        _userRepository = userRepository;
        _shoeRepository = shoeRepository;
    }

    public async Task<Unit> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var shoe = await _shoeRepository.GetByIdAsync(request.Dto.ShoeId);

        if (shoe is null)
            throw new NotFoundException("Shoe not found");

        var userId = _userRepository.GetUserId!.Value;

        var doesUserHaveReviewForShoe = await _reviewRepository.DoesUserHaveReviewForShoe(userId, request.Dto.ShoeId);

        if (doesUserHaveReviewForShoe)
            throw new BadRequestException("This user already has review for this shoe");

        var numberOfRatings = shoe.NumberOfRatings++;

        shoe.AverageRating = (shoe.AverageRating + request.Dto.ShoeRate) / numberOfRatings;

        await _shoeRepository.UpdateAsync(shoe);

        await _reviewRepository.CreateAsync(new Domain.Entities.Review()
        {
            ShoeId = request.Dto.ShoeId,
            UserId = userId,
            Title = request.Dto.Title,
            ReviewDescription = request.Dto.ReviewDescription,
            ShoeRate = request.Dto.ShoeRate
        });

        return Unit.Value;
    }
}
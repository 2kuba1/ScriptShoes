using MediatR;
using ScriptShoes.Application.Common;
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

        var user = await GetUserByHttpContextId.Get(_userRepository);

        var doesUserHaveReviewForShoe = await _reviewRepository.DoesUserHaveReviewForShoe(user.Id, request.Dto.ShoeId);

        if (doesUserHaveReviewForShoe)
            throw new BadRequestException("This user already has review for this shoe");

        var numberOfReviews = ++shoe.NumberOfReviews;

        Console.WriteLine(shoe.AverageRating);
        
        if (shoe.AverageRating == 0)
        {
            Console.WriteLine("XD");
            shoe.AverageRating = request.Dto.ShoeRate;
        }
        else
        {
            var avgRating = (shoe.AverageRating + request.Dto.ShoeRate) / numberOfReviews;
            shoe.AverageRating = avgRating;
        }

        await _shoeRepository.UpdateAsync(shoe);

        await _reviewRepository.CreateAsync(new Domain.Entities.Review()
        {
            ShoeId = request.Dto.ShoeId,
            UserId = user.Id,
            Title = request.Dto.Title,
            ReviewDescription = request.Dto.ReviewDescription,
            ShoeRate = request.Dto.ShoeRate,
            Username = user.Username
        });

        return Unit.Value;
    }
}
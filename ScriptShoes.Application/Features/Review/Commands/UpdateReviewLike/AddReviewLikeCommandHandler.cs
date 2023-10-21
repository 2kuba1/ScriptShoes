using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Domain.Exceptions;

namespace ScriptShoes.Application.Features.Review.Commands.UpdateReviewLike;

public class AddReviewLikeCommandHandler : IRequestHandler<AddReviewLikeCommand, Unit>
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IUserRepository _userRepository;
    private readonly IReviewLikeRepository _reviewLikeRepository;

    public AddReviewLikeCommandHandler(IReviewRepository reviewRepository, IUserRepository userRepository,
        IReviewLikeRepository reviewLikeRepository)
    {
        _reviewRepository = reviewRepository;
        _userRepository = userRepository;
        _reviewLikeRepository = reviewLikeRepository;
    }

    public async Task<Unit> Handle(AddReviewLikeCommand request, CancellationToken cancellationToken)
    {
        if (request.dto.UserId is null && request.dto.LocalUserId is null ||
            request.dto.UserId is not null && request.dto.LocalUserId is not null)
            throw new BadRequestException("UserId and LocalUserId can't be the same type");

        var review = await _reviewRepository.GetByIdAsync(request.dto.ReviewId);

        if (review is null)
            throw new NotFoundException("Review not found");

        if (request.dto.UserId is not null)
        {
            var user = await _userRepository.GetByIdAsync((int)request.dto.UserId);

            if (user is null) throw new NotFoundException("User not found");

            review.Likes++;
            await _reviewRepository.UpdateAsync(review);

            await _reviewLikeRepository.CreateAsync(new ReviewLike()
            {
                UserId = user.Id,
                ReviewId = review.Id,
                ShoeId = review.ShoeId
            });
            return Unit.Value;
        }

        if (request.dto.LocalUserId != null && !request.dto.LocalUserId.Contains("Local"))
            throw new BadRequestException("Incorrect UserLocalId");

        review.Likes++;
        await _reviewRepository.UpdateAsync(review);

        await _reviewLikeRepository.CreateAsync(new ReviewLike()
        {
            LocalId = request.dto.LocalUserId,
            ReviewId = review.Id,
            ShoeId = review.ShoeId
        });

        return Unit.Value;
    }
}
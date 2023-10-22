using MediatR;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Entities;
using ScriptShoes.Domain.Exceptions;

namespace ScriptShoes.Application.Features.Review.Commands.AddReviewLike;

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
        if (request.Dto.UserId is null && request.Dto.LocalUserId is null ||
            request.Dto.UserId is not null && request.Dto.LocalUserId is not null)
            throw new BadRequestException("UserId and LocalUserId can't be the same type");

        var review = await _reviewRepository.GetByIdAsync(request.Dto.ReviewId);

        if (review is null)
            throw new NotFoundException("Review not found");

        if (request.Dto.UserId is not null)
        {
            var user = await _userRepository.GetByIdAsync((int)request.Dto.UserId);

            if (user is null) throw new NotFoundException("User not found");

            var reviewLike = await _reviewLikeRepository.GetByReviewIdAndUserId(review.Id, user.Id);
            if (reviewLike is not null)
                throw new NotFoundException("Review like is already added");

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

        if (request.Dto.LocalUserId == null || !request.Dto.LocalUserId.Contains("Local"))
            throw new BadRequestException("Incorrect UserLocalId");

        var localUserReviewLike =
            await _reviewLikeRepository.GetByReviewIdAndUserId(review.Id, request.Dto.LocalUserId);
        if (localUserReviewLike is not null)
            throw new NotFoundException("Review like is already added");

        review.Likes++;
        await _reviewRepository.UpdateAsync(review);

        await _reviewLikeRepository.CreateAsync(new ReviewLike()
        {
            LocalId = request.Dto.LocalUserId,
            ReviewId = review.Id,
            ShoeId = review.ShoeId
        });

        return Unit.Value;
    }
}
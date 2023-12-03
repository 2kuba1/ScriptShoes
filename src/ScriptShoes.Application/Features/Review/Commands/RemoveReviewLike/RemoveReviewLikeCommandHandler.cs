using MediatR;
using ScriptShoes.Application.Common;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Exceptions;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Features.Review.Commands.RemoveReviewLike;

public class RemoveReviewLikeCommandHandler : IRequestHandler<RemoveReviewLikeCommand, Unit>
{
    
    private readonly IReviewRepository _reviewRepository;
    private readonly IUserRepository _userRepository;
    private readonly IReviewLikeRepository _reviewLikeRepository;

    public RemoveReviewLikeCommandHandler(IReviewRepository reviewRepository, IUserRepository userRepository,
        IReviewLikeRepository reviewLikeRepository)
    {
        _reviewRepository = reviewRepository;
        _userRepository = userRepository;
        _reviewLikeRepository = reviewLikeRepository;
    }
    
    public async Task<Unit> Handle(RemoveReviewLikeCommand request, CancellationToken cancellationToken)
    {
        if (request.Dto.UserId is null && request.Dto.LocalUserId is null ||
            request.Dto.UserId is not null && request.Dto.LocalUserId is not null)
            throw new BadRequestException("UserId and LocalUserId can't be the same type");

        var review = await _reviewRepository.GetByIdAsync(request.Dto.ReviewId);

        if (review is null)
            throw new NotFoundException("Review not found");

        if (request.Dto.UserId is not null)
        {
            var user = await GetUserByHttpContextId.Get(_userRepository);

            if (user.Id != request.Dto.UserId)
                throw new NotFoundException("User not found");

            var reviewLike = await _reviewLikeRepository.GetByReviewIdAndUserId(review.Id, user.Id);
            if (reviewLike is null)
                throw new NotFoundException("Review like not found");
            
            review.Likes--;
            await _reviewRepository.UpdateAsync(review);


            await _reviewLikeRepository.DeleteAsync(reviewLike);
            return Unit.Value;
        }

        if (request.Dto.LocalUserId == null || !request.Dto.LocalUserId.Contains("Local"))
            throw new BadRequestException("Incorrect UserLocalId");

        var localUserReviewLike = await _reviewLikeRepository.GetByReviewIdAndUserId(review.Id, request.Dto.LocalUserId);
        if (localUserReviewLike is null)
            throw new NotFoundException("Review like not found");
        
        review.Likes--;
        await _reviewRepository.UpdateAsync(review);

        await _reviewLikeRepository.DeleteAsync(localUserReviewLike);

        return Unit.Value;
    }
}
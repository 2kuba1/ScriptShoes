using MediatR;
using ScriptShoes.Application.Common;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Exceptions;

namespace ScriptShoes.Application.Features.Review.Queries.GetLikedReviews;

public class GetLikedReviewsQueryHandler : IRequestHandler<GetLikedReviewsQuery, List<int>>
{
    private readonly IUserRepository _userRepository;
    private readonly IReviewLikeRepository _reviewLikeRepository;

    public GetLikedReviewsQueryHandler(IUserRepository userRepository, IReviewLikeRepository reviewLikeRepository)
    {
        _userRepository = userRepository;
        _reviewLikeRepository = reviewLikeRepository;
    }

    public async Task<List<int>> Handle(GetLikedReviewsQuery request, CancellationToken cancellationToken)
    {
        if (request.UserId is null && request.LocalUserId is null ||
            request.UserId is not null && request.LocalUserId is not null)
            throw new BadRequestException("UserId and LocalUserId can't be the same type");

        if (request.UserId is not null)
        {
            var user = await GetUserByHttpContextId.Get(_userRepository);

            if (user.Id != request.UserId)
                throw new NotFoundException("User not found");
            
            return await _reviewLikeRepository.GetLikedReviews(request.ShoeId, (int)request.UserId) as List<int> ??
                   new List<int>();
        }

        if (request.LocalUserId == null || !request.LocalUserId.Contains("Local"))
            throw new BadRequestException("Incorrect UserLocalId");

        return await _reviewLikeRepository.GetLikedReviews(request.ShoeId, request.LocalUserId) as List<int> ??
               new List<int>();
    }
}
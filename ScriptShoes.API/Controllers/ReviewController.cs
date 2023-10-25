using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScriptShoes.Application.Features.Review.Commands;
using ScriptShoes.Application.Features.Review.Commands.AddReviewLike;
using ScriptShoes.Application.Features.Review.Commands.DeleteReview;
using ScriptShoes.Application.Features.Review.Commands.RemoveReviewLike;
using ScriptShoes.Application.Features.Review.Queries.GetLikedReviews;
using ScriptShoes.Application.Features.Review.Queries.GetPagedReviews;
using ScriptShoes.Application.Features.Review.Queries.GetShoeReviews;
using ScriptShoes.Application.Models;
using ScriptShoes.Application.Models.Review;

namespace ScriptShoes.API.Controllers;

[ApiController]
[Route("api/review")]
public class ReviewController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReviewController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("create")]
    [Authorize(Policy = "AuthUser")]
    public async Task<ActionResult> CreateReview([FromBody] CreateReviewDto dto)
    {
        await _mediator.Send(new CreateReviewCommand(dto));
        return NoContent();
    }

    [HttpGet]
    [Route("getShoeReviews/{shoeId:int}")]
    [AllowAnonymous]
    public async Task<ActionResult<List<GetShoeReviewsDto>>> GetShoeReviews([FromRoute] int shoeId)
    {
        var reviews = await _mediator.Send(new GetShoeReviewsQuery(shoeId));
        return Ok(reviews);
    }

    [HttpDelete]
    [Authorize(Policy = "AuthAdmin")]
    [Route("deleteReview/{reviewId:int}")]
    public async Task<ActionResult> DeleteReview([FromRoute] int reviewId)
    {
        await _mediator.Send(new DeleteReviewCommand(reviewId));
        return NoContent();
    }

    [HttpPost]
    [Route("addLike")]
    public async Task<ActionResult> AddLike([FromBody] AddReviewLikeDto dto)
    {
        await _mediator.Send(new AddReviewLikeCommand(dto));
        return NoContent();
    }

    [HttpDelete]
    [Route("removeLike")]
    public async Task<ActionResult> RemoveLike([FromBody] RemoveReviewLikeDto dto)
    {
        await _mediator.Send(new RemoveReviewLikeCommand(dto));
        return NoContent();
    }

    [HttpGet]
    [Route("getLikedReviews/{shoeId:int}")]
    public async Task<ActionResult<List<int>>> GetLikedReviews([FromRoute] int shoeId, [FromQuery] int? userId,
        [FromQuery] string? localUserId)
    {
        var likedReviews = await _mediator.Send(new GetLikedReviewsQuery(shoeId, userId, localUserId));
        return Ok(likedReviews);
    }

    [HttpGet]
    [Route("getPagedReviews")]
    public async Task<ActionResult<PagedResult<GetPagedReviewsQuery>>> GetPagedReviews([FromQuery] int shoeId,
        [FromQuery] int pageNumber, [FromQuery] int pageSize)
    {
        var pagedReviews = await _mediator.Send(new GetPagedReviewsQuery(shoeId, pageNumber, pageSize));
        return Ok(pagedReviews);
    }
}
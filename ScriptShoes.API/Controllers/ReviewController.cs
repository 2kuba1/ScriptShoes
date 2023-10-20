using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScriptShoes.Application.Features.Review.Commands;
using ScriptShoes.Application.Features.Review.Queries.GetShoeReviews;
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
}
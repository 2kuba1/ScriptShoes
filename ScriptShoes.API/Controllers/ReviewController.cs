using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScriptShoes.Application.Features.Review.Commands;
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
    public async Task<ActionResult> CreateReview([FromBody] CreateReviewDto dto)
    {
        await _mediator.Send(new CreateReviewCommand(dto));
        return NoContent();
    }
}
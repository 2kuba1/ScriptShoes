using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScriptShoes.Application.Features.Shoe.Commands;
using ScriptShoes.Application.Models.Shoe;

namespace ScriptShoes.API.Controllers;

[Route("api/shoe")]
[ApiController]
public class ShoeController : ControllerBase
{
    private readonly IMediator _mediator;

    public ShoeController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    [Route("create")]
    public async Task<ActionResult> CreateShoe([FromBody] CreateShoeDto dto)
    {
        var shoeId = await _mediator.Send(new CreateShoeCommand(dto));
        return Created($"/api/shoe/{shoeId}", null);
    }
}
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScriptShoes.Application.Features.Shoe.Commands.AddShoeThumbnail;
using ScriptShoes.Application.Features.Shoe.Commands.CreateShoe;
using ScriptShoes.Application.Features.Shoe.Commands.DeleteShoe;
using ScriptShoes.Application.Features.Shoe.Commands.UpdateShoe;
using ScriptShoes.Application.Features.Shoe.Queries.GetAllShoes;
using ScriptShoes.Application.Features.Shoe.Queries.GetFilters;
using ScriptShoes.Application.Features.Shoe.Queries.GetShoeById;
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

    [HttpGet]
    [Route("getAll")]
    public async Task<ActionResult<List<GetShoeDto>>> GetAllShoes()
    {
        var shoes = await _mediator.Send(new GetAllShoesQuery());

        return Ok(shoes);
    }

    [HttpGet]
    [Route("getById/{id:int}")]
    public async Task<ActionResult<GetShoeDto>> GetById([FromRoute] int id)
    {
        var shoe = await _mediator.Send(new GetShoeByIdQuery(id));

        return Ok(shoe);
    }

    [HttpGet]
    [Route("getFilters")]
    [ResponseCache(VaryByHeader = "User-Agent", Duration = 86400)]
    public async Task<ActionResult<GetFiltersDto>> GetFilters()
    {
        var filter = await _mediator.Send(new GetFiltersQuery());

        return Ok(filter);
    }

    [HttpDelete]
    [Route("delete")]
    public async Task<ActionResult> DeleteShoe([FromQuery] int id)
    {
        await _mediator.Send(new DeleteShoeCommand(id));
        return Ok();
    }

    [HttpPut]
    [Route("update")]
    public async Task<ActionResult> UpdateShoe([FromQuery] int id, [FromBody] UpdateShoeDto dto)
    {
        await _mediator.Send(new UpdateShoeCommand(id, dto));
        return NoContent();
    }

    [HttpPut]
    [Route("updateThumbnailImage")]
    public async Task<ActionResult> UpdateThumbnail([FromQuery] int id, [FromQuery] string url)
    {
        await _mediator.Send(new UpdateShoeThumbnailCommand(id, url));
        return NoContent();
    }
}
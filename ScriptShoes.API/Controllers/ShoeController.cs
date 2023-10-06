using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScriptShoes.Application.Features.Shoe.Commands;
using ScriptShoes.Application.Features.Shoe.Commands.CreateShoe;
using ScriptShoes.Application.Features.Shoe.Queries.GetAllShoes;
using ScriptShoes.Application.Features.Shoe.Queries.GetFiltersQuery;
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
        var shoe= await _mediator.Send(new GetShoeByIdQuery(id));

        return Ok(shoe);
    }

    [HttpGet]
    [Route("getFilters")]
    public async Task<ActionResult<GetFiltersDto>> GetFilters()
    {
        var filter = await _mediator.Send(new GetFiltersQuery());

        return Ok(filter);
    }
}
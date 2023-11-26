using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using ScriptShoes.Application.Features.Shoe.Commands.CreateShoe;
using ScriptShoes.Application.Features.Shoe.Commands.DeleteShoe;
using ScriptShoes.Application.Features.Shoe.Commands.DeleteShoeImages;
using ScriptShoes.Application.Features.Shoe.Commands.UpdateShoe;
using ScriptShoes.Application.Features.Shoe.Queries.GetAllShoes;
using ScriptShoes.Application.Features.Shoe.Queries.GetFilters;
using ScriptShoes.Application.Features.Shoe.Queries.GetPagedShoes;
using ScriptShoes.Application.Features.Shoe.Queries.GetShoeById;
using ScriptShoes.Application.Features.Shoe.Queries.GetShoeByType;
using ScriptShoes.Application.Features.Shoe.Queries.GetShoeContent;
using ScriptShoes.Application.Features.Shoe.Queries.SearchForShoes;
using ScriptShoes.Application.Models;
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
    [Authorize(Policy = "AuthAdmin")]
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

    [HttpPut]
    [Route("update")]
    [Authorize(Policy = "AuthAdmin")]
    public async Task<ActionResult> UpdateShoe([FromQuery] int id, [FromBody] UpdateShoeDto dto)
    {
        await _mediator.Send(new UpdateShoeCommand(id, dto));
        return NoContent();
    }

    [HttpDelete]
    [Route("delete")]
    [Authorize(Policy = "AuthAdmin")]
    public async Task<ActionResult> DeleteShoe([FromQuery] int id)
    {
        await _mediator.Send(new DeleteShoeCommand(id));
        return NoContent();
    }

    [HttpDelete]
    [Route("deleteImages")]
    [Authorize(Policy = "AuthAdmin")]
    public async Task<ActionResult> DeleteShoeImages([FromQuery] int id, [FromBody] List<int> imageIndexes)
    {
        await _mediator.Send(new DeleteShoeImagesCommand(id, imageIndexes));
        return NoContent();
    }

    [HttpGet]
    [Route("getPagedShoes")]
    public async Task<ActionResult<PagedResult<GetShoeLimitedInformationDto>>> GetPagedShoes([FromQuery] int pageNumber,
        [FromQuery] int pageSize)
    {
        var pagedResults = await _mediator.Send(new GetPagedShoesQuery(pageNumber, pageSize));
        return Ok(pagedResults);
    }

    [HttpGet]
    [Route("getShoes/{searchPhrase}")]
    [DisableRateLimiting]
    public async Task<ActionResult<PagedResult<SearchForShoesDto>>> GetShoes([FromQuery] int pageNumber,
        [FromQuery] int pageSize, [FromRoute] string searchPhrase)
    {
        var shoes = await _mediator.Send(new SearchForShoesQuery(pageSize, pageNumber, searchPhrase));
        return Ok(shoes);
    }

    [HttpGet]
    [Route("getShoeContent/{shoeId:int}")]
    public async Task<ActionResult<GetShoeContentDto>> GetShoeContent([FromRoute] int shoeId)
    {
        var shoe = await _mediator.Send(new GetShoeContentQuery(shoeId));
        return Ok(shoe);
    }

    [HttpGet]
    [Route("getShoesByType")]
    public async Task<ActionResult<List<GetShoeLimitedInformationDto>>> GetShoesByType([FromQuery] string shoeType,
        [FromQuery] int count)
    {
        var shoes = await _mediator.Send(new GetShoeByTypeQuery(shoeType, count));
        return Ok(shoes);
    }
}
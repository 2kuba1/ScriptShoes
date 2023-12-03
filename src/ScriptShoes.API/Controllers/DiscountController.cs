using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScriptShoes.Application.Features.Discount.Commands;
using ScriptShoes.Application.Features.Discount.Commands.CreateDiscount;
using ScriptShoes.Application.Features.Discount.Commands.RemoveDiscount;
using ScriptShoes.Application.Features.Discount.Commands.RemoveShoeFromDiscount;
using ScriptShoes.Application.Models.Discount;

namespace ScriptShoes.API.Controllers;

[Route("api/discount")]
[ApiController]
[Authorize(Policy = "AuthAdmin")]
public class DiscountController : ControllerBase
{
    private readonly IMediator _mediator;

    public DiscountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Route("create")]
    [HttpPost]
    public async Task<ActionResult> CreateDiscount([FromBody] CreateDiscountDto dto)
    {
        await _mediator.Send(new CreateDiscountCommand(dto));
        return NoContent();
    }

    [Route("delete/{discountId:int}")]
    [HttpDelete]
    public async Task<ActionResult> DeleteDiscount([FromRoute] int discountId)
    {
        await _mediator.Send(new RemoveDiscountCommand(discountId));
        return NoContent();
    }

    [Route("removeShoeFromDiscount/{shoeId:int}")]
    [HttpDelete]
    public async Task<ActionResult> RemoveFromDiscount([FromRoute] int shoeId)
    {
        await _mediator.Send(new RemoveShoeFromDiscountCommand(shoeId));
        return new NoContentResult();
    }
}
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScriptShoes.Application.Features.Cart;
using ScriptShoes.Application.Features.Cart.Commands.UpdateCart;
using ScriptShoes.Application.Features.Cart.Queries;
using ScriptShoes.Application.Features.Cart.Queries.GetItemsFromCart;
using ScriptShoes.Application.Models.Cart;

namespace ScriptShoes.API.Controllers;

[ApiController]
[Route("api/cart")]
[Authorize(Policy = "AuthUser")]
public class CartController : ControllerBase
{
    private readonly IMediator _mediator;

    public CartController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("updateCart/shoe/{shoeId:int}/count/{itemsCount:int}")]
    public async Task<ActionResult> UpdateCart([FromRoute] int shoeId,
        [FromRoute] int itemsCount)
    {
        await _mediator.Send(new UpdateCartCommand(shoeId, itemsCount));
        return NoContent();
    }

    [HttpGet]
    [Route("getCart")]
    public async Task<ActionResult<GetCartDto>> GetCart()
    {
        var cart = await _mediator.Send(new GetItemsFromCartQuery());
        return Ok(cart);
    }
}
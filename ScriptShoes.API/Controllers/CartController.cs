using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScriptShoes.Application.Features.Cart;
using ScriptShoes.Application.Features.Cart.Commands.AddToCart;

namespace ScriptShoes.API.Controllers;

[ApiController]
[Authorize(Policy = "AuthUser")]
[Route("api/user/{userId:int}/cart")]
public class CartController : ControllerBase
{
    private readonly IMediator _mediator;

    public CartController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("addItem/shoe/{shoeId:int}/count/{itemsCount:int}")]
    public async Task<ActionResult> AddItemToCart([FromRoute] int userId, [FromRoute] int shoeId,
        [FromRoute] int itemsCount)
    {
        await _mediator.Send(new AddToCartCommand(userId, shoeId, itemsCount));
        return NoContent();
    }
}
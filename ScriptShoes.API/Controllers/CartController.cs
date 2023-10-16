using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScriptShoes.Application.Features.Cart;
using ScriptShoes.Application.Features.Cart.Commands.UpdateCart;

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
    [Route("updateCart/shoe/{shoeId:int}/count/{itemsCount:int}")]
    public async Task<ActionResult> UpdateCart([FromRoute] int userId, [FromRoute] int shoeId,
        [FromRoute] int itemsCount)
    {
        await _mediator.Send(new UpdateCartCommand(userId, shoeId, itemsCount));
        return NoContent();
    }
}
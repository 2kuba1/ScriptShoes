using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScriptShoes.Application.Features.Orders.Commands.CheckoutPayment;
using ScriptShoes.Application.Features.Orders.Commands.ConfirmOrder;
using ScriptShoes.Application.Features.Orders.Commands.RemoveOrder;
using ScriptShoes.Application.Features.Orders.Queries.GetPagedOrders;
using ScriptShoes.Application.Features.Orders.Queries.GetUserOrders;
using ScriptShoes.Application.Models;
using ScriptShoes.Application.Models.Order;
using ScriptShoes.Domain.Exceptions;
using Stripe;

namespace ScriptShoes.API.Controllers;

[ApiController]
[Route("api/order")]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;

    public OrderController(IMediator mediator, IConfiguration configuration)
    {
        _mediator = mediator;
        _configuration = configuration;
    }

    [HttpPost]
    [Route("order")]
    public async Task<ActionResult<string>> Pay([FromBody] OrderDto dto)
    {
        var url = await _mediator.Send(new CheckoutPaymentCommand(dto));
        Response.Headers.Add("Location", url);

        return Ok(url);
    }

    [HttpPost]
    [Route("confirm")]
    public async Task<ActionResult> ConfirmPayment()
    {
        var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

        try
        {
            var stripeEvent = EventUtility.ConstructEvent(
                json,
                Request.Headers["Stripe-Signature"],
                _configuration.GetSection("Stripe:WebHookSecret").Get<string>()
            );

            // Handle the checkout.session.completed event
            if (stripeEvent.Type == Events.CheckoutSessionCompleted)
            {
                var data = stripeEvent.Data.Object as Stripe.Checkout.Session;

                if (data is null)
                    throw new NotFoundException("Payment data not found");

                await _mediator.Send(new ConfirmOrderCommand(data.Id));
            }

            return Ok();
        }
        catch (StripeException)
        {
            return BadRequest();
        }
    }

    [HttpDelete]
    [Authorize(Policy = "AuthAdmin")]
    [Route("removeOrder")]
    public async Task<ActionResult> RemoveOrder([FromQuery] string sessionId)
    {
        await _mediator.Send(new RemoveOrderCommand(sessionId));
        return NoContent();
    }

    [HttpGet]
    [Authorize(Policy = "AuthUser")]
    [Route("getUserOrders")]
    public async Task<ActionResult<PagedResult<UserOrdersDto>>> GetUserOrders([FromQuery] int pageSize,
        [FromQuery] int pageNumber)
    {
        var orders = await _mediator.Send(new GetUserOrdersQuery(pageSize, pageNumber));
        return Ok(orders);
    }

    [HttpGet]
    [Authorize(Policy = "AuthAdmin")]
    [Route("getPagedOrders")]
    public async Task<ActionResult<PagedResult<GetOrdersDto>>> GetPagedOrders([FromQuery] int pageSize,
        [FromQuery] int pageNumber)
    {
        var orders = await _mediator.Send(new GetPagedOrdersQuery(pageSize, pageNumber));
        return Ok(orders);
    }
}
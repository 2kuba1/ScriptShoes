using System.Text.Json;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScriptShoes.Application.Features.Orders.Commands.CheckoutPayment;
using ScriptShoes.Application.Features.Orders.Commands.ConfirmOrder;
using ScriptShoes.Application.Models.Payments;
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
    [Route("pay")]
    public async Task<ActionResult<string>> Pay([FromBody] List<PaymentRequestDto> dto)
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
        catch (StripeException e)
        {
            return BadRequest();
        }
    }
}
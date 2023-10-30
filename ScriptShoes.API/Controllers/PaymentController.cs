using MediatR;
using Microsoft.AspNetCore.Mvc;
using ScriptShoes.Application.Features.Payments.Commands.CheckoutPayment;
using ScriptShoes.Application.Models.Payments;

namespace ScriptShoes.API.Controllers;

[ApiController]
[Route("api/payments")]
public class PaymentController : ControllerBase
{
    private readonly IMediator _mediator;

    public PaymentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<string>> Pay([FromBody] List<PaymentRequestDto> dto)
    {
        var url = await _mediator.Send(new CheckoutPaymentCommand(dto));
        Response.Headers.Add("Location", url);

        return Ok(url);
    }
}
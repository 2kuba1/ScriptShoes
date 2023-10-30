using MediatR;
using ScriptShoes.Application.Models.Payments;

namespace ScriptShoes.Application.Features.Payments.Commands.CheckoutPayment;

public record CheckoutPaymentCommand(List<PaymentRequestDto> Dto) : IRequest<string>;
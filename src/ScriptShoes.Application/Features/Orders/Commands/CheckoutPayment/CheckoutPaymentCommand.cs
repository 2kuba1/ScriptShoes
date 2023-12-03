using MediatR;
using ScriptShoes.Application.Models.Order;

namespace ScriptShoes.Application.Features.Orders.Commands.CheckoutPayment;

public record CheckoutPaymentCommand(OrderDto Dto) : IRequest<string>;
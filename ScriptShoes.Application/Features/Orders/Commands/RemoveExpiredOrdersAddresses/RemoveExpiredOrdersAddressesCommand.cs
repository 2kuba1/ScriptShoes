using MediatR;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Features.Orders.Commands.RemoveExpiredOrdersAddresses;

public record RemoveExpiredOrdersAddressesCommand(List<Order> ExpiredOrders) : IRequest<Unit>;
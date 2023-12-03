using MediatR;
using ScriptShoes.Domain.Entities;

namespace ScriptShoes.Application.Features.Orders.Commands.RemoveExpiredOrders;

public record RemoveExpiredOrdersCommand(List<Order> ExpiredOrders) : IRequest<Unit>;
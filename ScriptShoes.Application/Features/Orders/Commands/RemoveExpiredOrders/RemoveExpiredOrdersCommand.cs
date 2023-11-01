using MediatR;

namespace ScriptShoes.Application.Features.Orders.Commands.RemoveExpiredOrders;

public record RemoveExpiredOrdersCommand() : IRequest<Unit>;
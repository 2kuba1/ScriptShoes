using MediatR;

namespace ScriptShoes.Application.Features.Orders.Commands.RemoveOrder;

public record RemoveOrderCommand(string OrderSessionId) : IRequest<Unit>;
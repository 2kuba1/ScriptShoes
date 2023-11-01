using MediatR;

namespace ScriptShoes.Application.Features.Orders.Commands.ConfirmOrder;

public record ConfirmOrderCommand(string SessionId) : IRequest<Unit>;
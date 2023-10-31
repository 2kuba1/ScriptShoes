using MediatR;

namespace ScriptShoes.Application.Features.Payments.Commands.ConfirmOrder;

public record ConfirmOrderCommand(string SessionId) : IRequest<Unit>;
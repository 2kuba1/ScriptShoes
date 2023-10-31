using MediatR;

namespace ScriptShoes.Application.Features.Payments.Commands.RemoveExpiredOrders;

public record RemoveExpiredOrdersCommand() : IRequest<Unit>;
using MediatR;

namespace ScriptShoes.Application.Features.Cart.Commands.UpdateCart;

public record UpdateCartCommand(int UserId, int ShoeId, int ItemsCount) : IRequest<Unit>;
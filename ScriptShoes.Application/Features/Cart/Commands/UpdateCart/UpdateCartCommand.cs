using MediatR;

namespace ScriptShoes.Application.Features.Cart.Commands.UpdateCart;

public record UpdateCartCommand(int ShoeId, int ItemsCount) : IRequest<Unit>;
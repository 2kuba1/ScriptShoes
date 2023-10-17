using MediatR;

namespace ScriptShoes.Application.Features.Cart.Commands.RemoveFromCart;

public record RemoveFromCartCommand(int ShoeId,  int ItemsCount) : IRequest<Unit>;
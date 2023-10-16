using MediatR;

namespace ScriptShoes.Application.Features.Cart.Commands.AddToCart;

public record AddToCartCommand(int ShoeId, int ItemsCount) : IRequest<Unit>;
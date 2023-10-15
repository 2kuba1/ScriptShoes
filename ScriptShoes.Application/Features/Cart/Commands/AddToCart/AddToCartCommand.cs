using MediatR;

namespace ScriptShoes.Application.Features.Cart.Commands.AddToCart;

public record AddToCartCommand(int UserId, int ShoeId, int ItemsCount) : IRequest<Unit>;
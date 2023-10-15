using MediatR;

namespace ScriptShoes.Application.Features.Cart;

public record AddToCartCommand(int UserId, int ShoeId, int ItemsCount) : IRequest<Unit>;
using MediatR;
using ScriptShoes.Application.Models.Cart;

namespace ScriptShoes.Application.Features.Cart.Queries.GetItemsFromCart;

public record GetItemsFromCartQuery() : IRequest<List<GetCartDto>>;
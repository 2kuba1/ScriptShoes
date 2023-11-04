﻿using MediatR;
using ScriptShoes.Application.Common;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Models.Cart;

namespace ScriptShoes.Application.Features.Cart.Queries.GetItemsFromCart;

public class GetItemsFromCartQueryHandler : IRequestHandler<GetItemsFromCartQuery, List<GetCartDto>>
{
    private readonly ICartRepository _cartRepository;
    private readonly IUserRepository _userRepository;

    public GetItemsFromCartQueryHandler(ICartRepository cartRepository, IUserRepository userRepository)
    {
        _cartRepository = cartRepository;
        _userRepository = userRepository;
    }

    public async Task<List<GetCartDto>> Handle(GetItemsFromCartQuery request, CancellationToken cancellationToken)
    {
        var user = await GetUserByHttpContextId.Get(_userRepository);
        var shoes = await _cartRepository.GetShoesFromCart(user.Id);
        return shoes;
    }
}
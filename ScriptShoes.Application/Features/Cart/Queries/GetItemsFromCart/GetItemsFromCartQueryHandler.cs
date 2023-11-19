using Mapster;
using MediatR;
using ScriptShoes.Application.Common;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Models.Cart;

namespace ScriptShoes.Application.Features.Cart.Queries.GetItemsFromCart;

public class GetItemsFromCartQueryHandler : IRequestHandler<GetItemsFromCartQuery, List<GetCartDto>>
{
    private readonly ICartRepository _cartRepository;
    private readonly IUserRepository _userRepository;
    private readonly IShoeRepository _shoeRepository;

    public GetItemsFromCartQueryHandler(ICartRepository cartRepository, IUserRepository userRepository,
        IShoeRepository shoeRepository)
    {
        _cartRepository = cartRepository;
        _userRepository = userRepository;
        _shoeRepository = shoeRepository;
    }

    public async Task<List<GetCartDto>> Handle(GetItemsFromCartQuery request, CancellationToken cancellationToken)
    {
        var user = await GetUserByHttpContextId.Get(_userRepository);
        var cart = await _cartRepository.GetCartByUserId(user.Id);

        var items = new List<GetCartDto>();

        foreach (var item in cart)
        {
            var shoe = await _shoeRepository.GetByIdAsync(item.ShoeId);

            if (shoe is null)
                continue;

            items.Add(new GetCartDto()
            {
                Brand = shoe.Brand,
                ShoeName = shoe.ShoeName,
                CurrentPrice = shoe.CurrentPrice,
                ThumbnailImage = shoe.ThumbnailImage,
                ShoeId = shoe.Id,
                Quantity = shoe.Quantity
            });
        }

        return items;
    }
}
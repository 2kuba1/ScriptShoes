using MediatR;
using ScriptShoes.Application.Common;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Exceptions;

namespace ScriptShoes.Application.Features.Cart.Commands.AddToCart;

public class AddToCartCommandHandler : IRequestHandler<AddToCartCommand, Unit>
{
    private readonly ICartRepository _cartRepository;
    private readonly IUserRepository _userRepository;
    private readonly IShoeRepository _shoeRepository;

    public AddToCartCommandHandler(ICartRepository cartRepository, IUserRepository userRepository,
        IShoeRepository shoeRepository)
    {
        _cartRepository = cartRepository;
        _userRepository = userRepository;
        _shoeRepository = shoeRepository;
    }

    public async Task<Unit> Handle(AddToCartCommand request, CancellationToken cancellationToken)
    {
        var shoe = await _shoeRepository.GetByIdAsync(request.ShoeId);

        if (shoe is null)
            throw new NotFoundException("Shoe not found");

        var user = await GetUserByHttpContextId.Get(_userRepository);
        var userCart = await _cartRepository.GetByUserIdAndItemId(user.Id, request.ShoeId);

        if (userCart is null)
        {
            await _cartRepository.CreateAsync(new Domain.Entities.Cart()
            {
                UserId = user.Id,
                ShoeId = request.ShoeId,
                ItemCount = request.ItemsCount
            });

            return Unit.Value;
        }

        userCart.ItemCount += request.ItemsCount;

        await _cartRepository.UpdateAsync(userCart);

        return Unit.Value;
    }
}
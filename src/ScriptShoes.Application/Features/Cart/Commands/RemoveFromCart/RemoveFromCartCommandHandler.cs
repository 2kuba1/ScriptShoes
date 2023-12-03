using MediatR;
using ScriptShoes.Application.Common;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Exceptions;

namespace ScriptShoes.Application.Features.Cart.Commands.RemoveFromCart;

public class RemoveFromCartCommandHandler : IRequestHandler<RemoveFromCartCommand, Unit>
{
    private readonly IShoeRepository _shoeRepository;
    private readonly IUserRepository _userRepository;
    private readonly ICartRepository _cartRepository;

    public RemoveFromCartCommandHandler(ICartRepository cartRepository, IUserRepository userRepository,
        IShoeRepository shoeRepository)
    {
        _cartRepository = cartRepository;
        _userRepository = userRepository;
        _shoeRepository = shoeRepository;
    }

    public async Task<Unit> Handle(RemoveFromCartCommand request, CancellationToken cancellationToken)
    {
        var shoe = await _shoeRepository.GetByIdAsync(request.ShoeId);

        if (shoe is null)
            throw new NotFoundException("Shoe not found");

        var user = await GetUserByHttpContextId.Get(_userRepository);
        var userCart = await _cartRepository.GetByUserIdAndItemId(user.Id, request.ShoeId);

        if (userCart is null)
            throw new NotFoundException("Cart not found");


        if (userCart.ItemCount - request.ItemsCount <= 1)
        {
            await _cartRepository.DeleteAsync(userCart);
            return Unit.Value;
        }

        userCart.ItemCount -= request.ItemsCount;

        await _cartRepository.UpdateAsync(userCart);
        return Unit.Value;
    }
}
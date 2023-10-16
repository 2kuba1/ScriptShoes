using MediatR;
using ScriptShoes.Application.Common;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Domain.Exceptions;

namespace ScriptShoes.Application.Features.Cart.Commands.UpdateCart;

public class UpdateCartCommandHandler : IRequestHandler<UpdateCartCommand, Unit>
{
    private readonly ICartRepository _cartRepository;
    private readonly IUserRepository _userRepository;
    private readonly IShoeRepository _shoeRepository;

    public UpdateCartCommandHandler(ICartRepository cartRepository, IUserRepository userRepository,
        IShoeRepository shoeRepository)
    {
        _cartRepository = cartRepository;
        _userRepository = userRepository;
        _shoeRepository = shoeRepository;
    }

    public async Task<Unit> Handle(UpdateCartCommand request, CancellationToken cancellationToken)
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
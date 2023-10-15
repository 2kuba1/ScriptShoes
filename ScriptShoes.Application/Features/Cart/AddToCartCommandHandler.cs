using MediatR;
using ScriptShoes.Application.Contracts.Persistence;

namespace ScriptShoes.Application.Features.Cart;

public class AddToCartCommandHandler : IRequestHandler<AddToCartCommand, Unit>
{
    private readonly ICartRepository _repository;

    public AddToCartCommandHandler(ICartRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(AddToCartCommand request, CancellationToken cancellationToken)
    {
        var userCart = await _repository.GetByUserIdAndItemID(request.UserId, request.ShoeId);

        if (userCart is null)
        {
            await _repository.CreateAsync(new Domain.Entities.Cart()
            {
                UserId = request.UserId,
                ShoeId = request.ShoeId,
                ItemCount = request.ItemsCount
            });

            return Unit.Value;
        }

        userCart.ItemCount += request.ItemsCount;

        await _repository.UpdateAsync(userCart);

        return Unit.Value;
    }
}
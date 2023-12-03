using FluentValidation;
using ScriptShoes.Application.Features.Cart.Commands.AddToCart;

namespace ScriptShoes.Application.Validators.CartValidator;

public class AddToCartValidator : AbstractValidator<AddToCartCommand>
{
    public AddToCartValidator()
    {
        RuleFor(x => x.ItemsCount)
            .GreaterThan(0);
    }
}
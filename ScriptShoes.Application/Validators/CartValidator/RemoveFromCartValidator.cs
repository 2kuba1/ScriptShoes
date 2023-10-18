using FluentValidation;
using ScriptShoes.Application.Features.Cart.Commands.RemoveFromCart;

namespace ScriptShoes.Application.Validators.CartValidator;
 
public class RemoveFromCartValidator : AbstractValidator<RemoveFromCartCommand>
{
    public RemoveFromCartValidator()
    {
        RuleFor(x => x.ItemsCount)
            .GreaterThan(0);
    }
}
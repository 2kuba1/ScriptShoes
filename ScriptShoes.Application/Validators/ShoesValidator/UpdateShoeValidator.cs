using FluentValidation;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Features.Shoe.Commands.UpdateShoe;

namespace ScriptShoes.Application.Validators.ShoesValidator;

public class UpdateShoeValidator : AbstractValidator<UpdateShoeCommand>
{
    public UpdateShoeValidator(IShoeRepository repository)
    {
        RuleFor(x => x.Dto.NewName)
            .CustomAsync(async (value, context, cancellationToken) =>
            {
                if (value is null)
                    return;

                var shoe = await repository.GetByNameAsync(value);
                if (shoe.ShoeName == value)
                    context.AddFailure("This shoe already exist");
            });

        RuleFor(x => x.Dto.CurrentPrice)
            .GreaterThan(0);
    }
}
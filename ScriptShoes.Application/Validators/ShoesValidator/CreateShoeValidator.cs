using FluentValidation;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Features.Shoe.Commands.CreateShoe;

namespace ScriptShoes.Application.Validators.ShoesValidator;

public class CreateShoeValidator : AbstractValidator<CreateShoeCommand>
{
    public CreateShoeValidator(IShoeRepository repository)
    {
        RuleFor(x => x.Dto.Brand)
            .NotNull();

        RuleFor(x => x.Dto.Images.Count)
            .LessThan(6)
            .GreaterThan(0);

        RuleFor(x => x.Dto.ThumbnailImage.Length)
            .LessThan(2);

        RuleFor(x => x.Dto.CurrentPrice)
            .GreaterThan(0);

        RuleFor(x => x.Dto.ShoeName)
            .NotNull()
            .CustomAsync(async (value, context, token) =>
            {
                var shoe = await repository.GetByNameAsync(value);
                
                if(shoe.ShoeName == value)
                    context.AddFailure("Shoe with this name already exist");
            });
    }
}
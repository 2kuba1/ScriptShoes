using FluentValidation;
using ScriptShoes.Application.Features.Review.Commands;

namespace ScriptShoes.Application.Validators.ReviewValidator;

public class CreateReviewValidator : AbstractValidator<CreateReviewCommand>
{
    public CreateReviewValidator()
    {
        RuleFor(x => x.Dto.Title)
            .MinimumLength(3)
            .MaximumLength(50);

        RuleFor(x => x.Dto.ReviewDescription)
            .MinimumLength(5)
            .MaximumLength(500);

        RuleFor(x => x.Dto.ShoeRate)
            .GreaterThanOrEqualTo(1)
            .LessThanOrEqualTo(5);
    }
}
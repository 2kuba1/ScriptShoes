using System.Text.RegularExpressions;
using FluentValidation;
using ScriptShoes.Application.Contracts.Persistence;
using ScriptShoes.Application.Features.User.Commands.Register;

namespace ScriptShoes.Application.Validators.UsersValidator;

public class RegisterValidator : AbstractValidator<RegisterCommand>
{
    public RegisterValidator(IUserRepository repository)
    {
        RuleFor(x => x.Dto.Email)
            .EmailAddress()
            .NotNull();

        RuleFor(x => x.Dto.Username)
            .MaximumLength(30)
            .MinimumLength(3);

        RuleFor(x => x.Dto.LastName)
            .MaximumLength(50)
            .MinimumLength(1)
            .NotNull();

        RuleFor(x => x.Dto.FirstName)
            .MaximumLength(50)
            .MinimumLength(1)
            .NotNull();

        RuleFor(x => x.Dto.ConfirmedPassword)
            .Equal(x => x.Dto.Password);

        RuleFor(x => x.Dto.Email)
            .CustomAsync(async (value, context, token) =>
            {
                var doesEmailExist = await repository.IsEmailEqual(value);

                if (doesEmailExist)
                    context.AddFailure("This email is already taken");
            });

        RuleFor(x => x.Dto.Password)
            .MinimumLength(8)
            .MaximumLength(25)
            .Must(HasValidPassword)
            .WithMessage("Password must contain special symbol, capital letter and digit");
    }

    private bool HasValidPassword(string pw)
    {
        var lowercase = new Regex("[a-z]+");
        var uppercase = new Regex("[A-Z]+");
        var digit = new Regex("(\\d)+");
        var symbol = new Regex("(\\W)+");

        return (lowercase.IsMatch(pw) && uppercase.IsMatch(pw) && digit.IsMatch(pw) && symbol.IsMatch(pw));
    }
}
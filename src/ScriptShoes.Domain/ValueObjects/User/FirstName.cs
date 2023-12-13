using ScriptShoes.Domain.Exceptions;

namespace ScriptShoes.Domain.ValueObjects.User;

public sealed record FirstName
{
    public string Value { get; }

    //constraints

    private const int MinLength = 1;
    private const int MaxLength = 50;

    public FirstName()
    {
    }

    public FirstName(string value)
    {
        Value = value ?? throw new InvalidFirstNameException();

        if (value.Length is < MinLength or > MaxLength)
            throw new InvalidFirstNameException(value);

        Value = value;
    }

    public static implicit operator string(FirstName firstName) => firstName.Value;
    public static implicit operator FirstName(string firstName) => new(firstName);
};
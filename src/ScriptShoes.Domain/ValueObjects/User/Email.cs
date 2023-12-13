using System.ComponentModel.DataAnnotations;
using ScriptShoes.Domain.Exceptions;

namespace ScriptShoes.Domain.ValueObjects.User;

public sealed record Email
{
    public string Value { get; }

    private readonly EmailAddressAttribute _emailAddressAttribute = new();

    private Email()
    {
    }

    public Email(string value)
    {
        Value = value ?? throw new InvalidEmailException();
        if (!_emailAddressAttribute.IsValid(value))
            throw new InvalidEmailException(value);

        Value = value;
    }

    public static implicit operator string(Email passwordHash) => passwordHash.Value;
    public static implicit operator Email(string value) => new(value);
}
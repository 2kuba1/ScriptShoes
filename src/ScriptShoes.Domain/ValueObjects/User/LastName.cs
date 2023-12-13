using ScriptShoes.Domain.Exceptions;

namespace ScriptShoes.Domain.ValueObjects.User;

public sealed record LastName
{
    public string Value { get; }

    //constraints 

    private const int MinLength = 1;
    private const int MaxLength = 50;
    
    public LastName()
    {
    }

    public LastName(string value)
    {
        Value = value ?? throw new InvalidLastNameException();
        
        if(value.Length is < MinLength or > MaxLength)
            throw new InvalidLastNameException(value);
        
        Value = value;
    }

    public static implicit operator string(LastName lastName) => lastName.Value;
    public static implicit operator LastName(string lastName) => new(lastName);
};
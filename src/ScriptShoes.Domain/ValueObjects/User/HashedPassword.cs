using ScriptShoes.Domain.Exceptions;

namespace ScriptShoes.Domain.ValueObjects.User;

public sealed record HashedPassword
{
    public string Value { get; }
    
    private HashedPassword(){}
    
    public HashedPassword(string value)
    {
        Value = value ?? throw new InvalidPasswordException();
    }
    
    public static implicit operator string(HashedPassword passwordHash) => passwordHash.Value;
    public static implicit operator HashedPassword(string value) => new(value);
}
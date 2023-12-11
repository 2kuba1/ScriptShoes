using ScriptShoes.Domain.Exceptions;

namespace ScriptShoes.Domain.ValueObjects.User;

public record Username
{
    public string Value { get; private set; }

    //constraints

    private const int MaxLength = 30;
    private const int MinLength = 3;

    private Username()
    {
    }

    public Username(string value)
    {
        if (value.Length is < MinLength or > MaxLength)
            throw new InvalidUsernameException(value);

        Value = value;
    }

    public static implicit operator string(Username username) => username.Value;
    public static implicit operator Username(string username) => new(username);
}
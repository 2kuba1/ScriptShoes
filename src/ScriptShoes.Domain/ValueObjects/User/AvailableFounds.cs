using System.Globalization;
using ScriptShoes.Domain.Exceptions;

namespace ScriptShoes.Domain.ValueObjects.User;

public record AvailableFounds
{
    public float Value { get; }

    //constraints

    private const int MaxDecimalPoint = 2;

    private AvailableFounds()
    {
    }

    public AvailableFounds(float value)
    {
        if (!value.ToString(CultureInfo.CurrentCulture).Contains('.')) return;

        if (value.ToString(CultureInfo.CurrentCulture).Split('.')[1].Length > MaxDecimalPoint)
            throw new InvalidAvailableFoundsException(value);

        Value = value;
    }

    public static implicit operator float(AvailableFounds availableFounds) => availableFounds.Value;
    public static implicit operator AvailableFounds(float value) => new(value);
}
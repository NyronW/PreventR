using System.Numerics;

namespace PreventR;

public static class NumericPreventionExtensions
{
    public static Prevent<TValue> LessThanOrEqualZero<TValue>(this Prevent<TValue> prevent, string exceptionMessage = null!) where TValue : INumber<TValue>
    {
        if (prevent <= TValue.Zero) prevent.ThrowException(new ArgumentOutOfRangeException(nameof(prevent), exceptionMessage ?? "Value is less than or equal to zero"));
        return prevent;
    }

    public static Prevent<TValue> LessThan<TValue>(this Prevent<TValue> prevent, TValue min, string exceptionMessage = null!) where TValue : INumber<TValue>
    {
        if (prevent < min) prevent.ThrowException(new ArgumentOutOfRangeException(exceptionMessage ?? $"Value must not be greater than {min}", innerException: null!));
        return prevent;
    }

    public static Prevent<TValue> GreaterThan<TValue>(this Prevent<TValue> prevent, TValue max, string exceptionMessage = null!) where TValue : INumber<TValue>
    {
        if (prevent > max) prevent.ThrowException(new ArgumentOutOfRangeException(exceptionMessage ?? $"Value must not be greater than {max}", innerException: null!));
        return prevent;
    }

    public static Prevent<TValue> Negative<TValue>(this Prevent<TValue> prevent, string exceptionMessage = null!) where TValue : INumber<TValue>
    {
        if (prevent < TValue.Zero) prevent.ThrowException(new ArgumentOutOfRangeException(nameof(prevent), exceptionMessage ?? "Value is negative"));
        return prevent;
    }

    public static Prevent<TValue> Zero<TValue>(this Prevent<TValue> prevent, string exceptionMessage = null!) where TValue : INumber<TValue>
    {
        if (prevent == TValue.Zero) prevent.ThrowException(new ArgumentOutOfRangeException(nameof(prevent), exceptionMessage ?? "Value is negative"));
        return prevent;
    }
}

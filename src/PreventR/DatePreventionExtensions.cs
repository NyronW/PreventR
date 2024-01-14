namespace PreventR;

public static class DatePreventionExtensions
{
    public static Prevent<DateTime> LessThan(this Prevent<DateTime> prevent, DateTime min, string exceptionMessage = null!)
    {
        if (prevent < min) prevent.ThrowException(new ArgumentOutOfRangeException(exceptionMessage ?? $"Value must not be greater than {min}", innerException: null!));
        return prevent;
    }

    public static Prevent<DateTime> GreaterThan(this Prevent<DateTime> prevent, DateTime max, string exceptionMessage = null!)
    {
        if (prevent > max) prevent.ThrowException(new ArgumentOutOfRangeException(exceptionMessage ?? $"Value must not be greater than {max}", innerException: null!));
        return prevent;
    }

    public static Prevent<DateTime> OutOfRange(this Prevent<DateTime> prevent, DateTime start, DateTime end, string exceptionMessage = null!)
    {
        prevent.Value.Prevent().LessThan(start, exceptionMessage)
            .GreaterThan(end, exceptionMessage);

        return prevent;
    }
}
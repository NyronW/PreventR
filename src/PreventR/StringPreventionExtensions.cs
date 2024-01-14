using System.Text.RegularExpressions;

namespace PreventR;

public static class StringPreventionExtensions
{
    public  static Prevent<string> Null(this Prevent<string> prevent, string exceptionMessage = null!)
    {
        if (prevent.Value is null) prevent.ThrowException(new ArgumentNullException(nameof(prevent), exceptionMessage));
        return prevent;
    }

    public static Prevent<string> NullOrEmpty(this Prevent<string> prevent, string exceptionMessage = null!)
    {
        if (string.IsNullOrEmpty(prevent)) prevent.ThrowException(new ArgumentNullException(nameof(prevent), exceptionMessage));
        return prevent;
    }

    public static Prevent<string> NullOrWhiteSpace(this Prevent<string> prevent, string exceptionMessage = null!)
    {
        if (string.IsNullOrWhiteSpace(prevent)) prevent.ThrowException(new ArgumentNullException(nameof(prevent), exceptionMessage));
        return prevent;
    }

    public static Prevent<string> NotNumeric(this Prevent<string> prevent, string exceptionMessage = null!)
    {
        if (!int.TryParse(prevent, out var _)) prevent.ThrowException(exceptionMessage ?? "String value is not numeric");
        return prevent;
    }

    public static Prevent<string> LengthGreaterTnan(this Prevent<string> prevent, int maxlength, string exceptionMessage = null!)
    {
        if (prevent.Value.Length > maxlength) prevent.ThrowException(exceptionMessage ?? $"String length cannot be greater than {maxlength}");
        return prevent;
    }

    public static Prevent<string> LengthLessTnan(this Prevent<string> prevent, int minlength, string exceptionMessage = null!)
    {
        if (prevent.Value.Length < minlength) prevent.ThrowException(exceptionMessage ?? $"String length cannot be less than {minlength}");
        return prevent;
    }

    public static Prevent<string> InvalidFormat(this Prevent<string> prevent, string regexPattern, string exceptionMessage = null!)
    {
        var m = Regex.Match(prevent.Value, regexPattern);
        if (!m.Success || prevent.Value != m.Value)
        {
            prevent.ThrowException($"Input {prevent.Name} was not in required format: {regexPattern}");
        }

        return prevent;
    }
}

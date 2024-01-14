using System.Diagnostics.CodeAnalysis;

namespace PreventR;

public static class Prevention
{
    public static Prevent<T> Prevent<T>(this T value)
    {
        return new(value);
    }

    public static Prevent<T> Prevent<T>(this T value, string name)
    {
        return new(value, name);
    }

    public static Prevent<T> Prevent<T>(this T value, Func<Exception> exceptionFactory)
    {
        return new(value, null!, null!, exceptionFactory);
    }

    public static Prevent<T> Prevent<T>(this T value, string name, string message)
    {
        return new(value, name, message);
    }

    public static Prevent<T> Prevent<T>(this T value, string name, Func<Exception> exceptionFactory)
    {
        return new(value, name, null!, exceptionFactory);
    }

    public static Prevent<T> Prevent<T>(this T value, string name, string message, Func<Exception> exceptionFactory)
    {
        return new(value, name, message, exceptionFactory);
    }
}


public readonly record struct Prevent<TValue>
{

    internal Prevent(TValue value) : this(value, null!, null!, null!)
    {
    }

    internal Prevent(TValue value, string name) : this(value, name, null!, null!)
    {
    }

    internal Prevent(TValue value, string name, string message) : this(value, name, message, null!)
    {
    }

    internal Prevent(TValue value, string name, string message, Func<Exception> exceptionFactory)
    {
        Value = value;
        Name = name;
        Message = message;
        ExceptionFactory = exceptionFactory;
    }

    public TValue Value { get; }

    public readonly Func<Exception> ExceptionFactory;
    public string Name { get; }
    public string Message { get; }

    public static implicit operator TValue([DisallowNull] Prevent<TValue> validatable) => validatable.Value;

    public override string ToString() => Value!.ToString()!;


    public void ThrowException(Exception exception)
    {
        if (exception is not null) throw exception;

        ThrowException("Invalid argument");
    }

    public void ThrowException(string message)
    {
        if (ExceptionFactory is not null) throw ExceptionFactory();

        if (!string.IsNullOrWhiteSpace(Message) && !string.IsNullOrWhiteSpace(Name)) throw new ArgumentException(Message, Name);

        if (!string.IsNullOrWhiteSpace(Message)) throw new ArgumentException(Message);

        if (!string.IsNullOrWhiteSpace(Name)) throw new ArgumentException("Invalid argument", Name);

        throw new ArgumentException(message!);
    }
}
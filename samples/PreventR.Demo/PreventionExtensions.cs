
using PreventR;

public static class PreventionExtensions
{
    public static Prevent<T> Foo<T>(this Prevent<T> prevent)
    {
        if (prevent.ToString().Equals("foo")) prevent.ThrowException($"Value 'Foo' is not allowed for argument:  {prevent.Name}");

        return prevent;
    }

}
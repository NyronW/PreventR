namespace PreventR;

public static class PredicatePreventionExtensions
{
    public static Prevent<T> Predicate<T>(this Prevent<T> prevent, Func<T, bool> func)
    {
        if (func(prevent.Value))
        {
            prevent.ThrowException(new ArgumentException(prevent.Message!, prevent.Name!));
        }

        return prevent;
    }

    public static async Task<Prevent<T>> Predicate<T>(this Prevent<T> prevent, Func<T, Task<bool>> func)
    {
        if (await func(prevent.Value))
        {
            throw new ArgumentException(prevent.Message!, prevent.Name!);
        }

        return prevent;
    }
}

using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace PreventR;

public static class CollectionPreventionExtensions
{
    public static Prevent<TValue> Empty<TValue>(this Prevent<TValue> prevent) where TValue : notnull, IEnumerable
    {
        var value = prevent.Value switch
        {
            ICollection collection => collection.Count,
            string s => s.Length,
            _ => GetEnumeratedCount(prevent.Value, true)
        };

        if (value == 0) prevent.ThrowException("Collection should not be empty.");
        return prevent;
    }

    public static Prevent<TCollection> MissingKey<TCollection, TKey>(this Prevent<TCollection> prevent,[DisallowNull] TKey key)
        where TCollection : notnull, IDictionary
        where TKey : notnull
    {
        if (!prevent.Value.Contains(key)) prevent.ThrowException(new KeyNotFoundException($"Key: {key} not found in in dictionary"));

        return prevent;
    }

    public static Prevent<TCollection> MissingKeys<TCollection, TKey>(this Prevent<TCollection> prevent,[DisallowNull] TKey[] keys)
        where TCollection : notnull, IDictionary
        where TKey : notnull
    {
        foreach (var key in keys)
            if (!prevent.Value.Contains(key)) prevent.ThrowException(new KeyNotFoundException($"Key: {key} not found in in dictionary"));

        return prevent;
    }

    private static int GetEnumeratedCount(IEnumerable enumerable, bool emptyCheck = false)
    {
        int count = 0;
        IEnumerator enumerator = enumerable.GetEnumerator();
        while (enumerator.MoveNext())
        {
            count++;
            if (emptyCheck) break;
        }

        return count;
    }
}

namespace FunctionalCSharp.Extensions;

public static class AppCollectionExtensions
{
    public static bool IsNullOrEmpty<T>(this ICollection<T>? source) 
        => source is not {Count: > 0};

    public static bool AddIfNotContains<T>(this ICollection<T> source, T item)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        if (source.Contains(item))
        {
            return false;
        }

        source.Add(item);
        return true;
    }

    public static IEnumerable<T> AddIfNotContains<T>(this ICollection<T> source, IEnumerable<T> items)
    {
        if (items == null) throw new ArgumentNullException(nameof(items));

        var addedItems = new List<T>();

        foreach (var item in items)
        {
            if (source.Contains(item))
            {
                continue;
            }

            source.Add(item);
            addedItems.Add(item);
        }

        return addedItems;
    }

    public static bool AddIfNotContains<T>(this ICollection<T> source,Func<T,bool> predicate, Func<T> itemFactory)
    {
            
        if (predicate == null) throw new ArgumentNullException(nameof(predicate));
        if (itemFactory == null) throw new ArgumentNullException(nameof(itemFactory));

        if (source.Any(predicate))
        {
            return false;
        }

        source.Add(itemFactory());
        return true;
    }

    public static IList<T> RemoveAll<T>(this ICollection<T> source, Func<T, bool> predicate)
    {
        var items = source.Where(predicate).ToList();

        foreach (var item in items)
        {
            source.Remove(item);
        }

        return items;
    }
}
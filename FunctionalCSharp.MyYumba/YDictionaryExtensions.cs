using static FunctionalCSharp.MyYumba.Y;


namespace FunctionalCSharp.MyYumba;

public static class YDictionaryExtensions
{
    // (IDictionary<K, R>, K) -> Option<R>
    public static YOption<R> YLookup<K, R>(this Dictionary<K, R> dictionary, K key) where K : notnull
        => dictionary.TryGetValue(key, out var value) ? YSome(value) : YNone;
    
    // (IDictionary<K, T>, (T, R)) -> IDictionary<K, R>
    public static Dictionary<K, R> YMap<K, T, R>(this Dictionary<K, T> dicT, Func<T, R> func ) where K : notnull
    {
        var dicR = new Dictionary<K, R>();
        foreach (var pair in dicT) dicR[pair.Key] = func(pair.Value);
        return dicR;
    }
        
    
}
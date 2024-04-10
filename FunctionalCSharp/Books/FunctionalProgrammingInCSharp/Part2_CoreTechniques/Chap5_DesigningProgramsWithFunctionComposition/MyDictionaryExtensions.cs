
using FunctionalCSharp.MyYumba;
using static FunctionalCSharp.MyYumba.Y;


namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition;

public static class MyDictionaryExtensions
{
    // (IDictionary<K, R>, K) -> Option<R>
    public static YOption<R> Lookup<K, R>(this Dictionary<K, R> dictionary, K key) where K : notnull
        => dictionary.TryGetValue(key, out var value) ? YSome(value) : YNone;
}
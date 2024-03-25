using System.Collections.Specialized;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition.OptionoClass;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part3_FunctionalDesigns.Chap8_FunctionalErrorHandling.Models;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition;

public static class MyNameValueCollectionExtensions
{
    // (NameValueCollection, string) -> Option<string>
    public static Optiono<string> Lookup(this NameValueCollection collection, string key) 
        => collection[key];
}

public static class MyDictionaryExtensions
{
    // (IDictionary<K, R>, K) -> Option<R>
    public static Optiono<R> Lookup<K, R>(this Dictionary<K, R> dictionary, K key) where K : notnull
        => dictionary.TryGetValue(key, out var value) ? MyF.Somo(value) : MyF.Nono;
}
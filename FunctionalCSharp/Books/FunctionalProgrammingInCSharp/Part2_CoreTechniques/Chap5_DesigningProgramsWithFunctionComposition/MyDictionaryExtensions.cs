using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition.OptionoClass;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition;

public static class MyDictionaryExtensions
{
    // (IDictionary<K, R>, K) -> Option<R>
    public static Optiono<R> Lookup<K, R>(this Dictionary<K, R> dictionary, K key) where K : notnull
        => dictionary.TryGetValue(key, out var value) ? MyF.Somo(value) : MyF.Nono;
}
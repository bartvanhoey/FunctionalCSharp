using System.Collections.Specialized;
using FunctionalCSharp.MyYumba;


namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition;

public static class MyNameValueCollectionExtensions
{
    // (NameValueCollection, string) -> Option<string>
    public static YOption<string> Lookup(this NameValueCollection collection, string key) 
        => collection[key];
}
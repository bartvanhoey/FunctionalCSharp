using System.Collections.Specialized;

namespace FunctionalCSharp.MyYumba;

public static class YValueCollectionExtensions
{
    // (NameValueCollection, string) -> Option<string>
    public static YOption<string> YLookup(this NameValueCollection collection, string key) 
        => collection[key];
}
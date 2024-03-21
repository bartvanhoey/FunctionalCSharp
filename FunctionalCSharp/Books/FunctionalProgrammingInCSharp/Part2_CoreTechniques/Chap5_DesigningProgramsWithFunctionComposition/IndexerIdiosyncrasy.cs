using System.Collections.Specialized;
using static System.Console;

// ReSharper disable CollectionNeverUpdated.Local

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition;

public static class IndexerIdiosyncrasy
{
    public static void WriteColorToScreen()
    {
        try
        {
            var empty = new NameValueCollection(); // returns null if key not present
            var green = empty["green"];
            WriteLine("green");

            var alsoEmpty = new Dictionary<string,string>(); // throws KeyNotFoundException if key not present
            var blue = alsoEmpty["blue"];   
            WriteLine("blue");
        }
        catch (Exception exception)
        {
            WriteLine(exception.GetType().Name);
        }
    } 
    
    
}
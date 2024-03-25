using System.Collections.Specialized;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition;

public static class IndexerLookupReturnsOption
{
    public static void WriteColorToScreen()
    {
        try
        {
            var empty = new NameValueCollection(); // returns null if key not present
            var optionGreen = empty.Lookup("green");
            var matchGreen = optionGreen.Match(() => "no value for green", x => x);
            Console.WriteLine(matchGreen);

            var alsoEmpty = new Dictionary<string,string>(); // throws KeyNotFoundException if key not present
            var optionBlue = alsoEmpty.Lookup("blue");
            var matchBlue = optionBlue.Match(() => "no value for blue", x => x);
            Console.WriteLine(matchBlue);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.GetType().Name);
        }
    } 
    
    
}
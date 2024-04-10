using System.Collections.Specialized;
using FunctionalCSharp.MyYumba;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition;

public static class IndexerLookupReturnsOption
{
    public static void WriteColorToScreen()
    {
        try
        {
            var empty = new NameValueCollection(); // returns null if key not present
            var optionGreen = empty.YLookup("green");
            var matchGreen = optionGreen.YMatch(() => "no value for green", x => x);
            Console.WriteLine(matchGreen);

            var alsoEmpty = new Dictionary<string,string>(); // throws KeyNotFoundException if key not present
            var optionBlue = alsoEmpty.YLookup("blue");
            var matchBlue = optionBlue.YMatch(() => "no value for blue", x => x);
            Console.WriteLine(matchBlue);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.GetType().Name);
        }
    } 
    
    
}
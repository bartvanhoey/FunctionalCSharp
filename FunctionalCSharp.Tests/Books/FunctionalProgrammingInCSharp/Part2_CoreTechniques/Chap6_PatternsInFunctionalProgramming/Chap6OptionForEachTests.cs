using FunctionalCSharp.MyYumba;
using static System.Console;
using static FunctionalCSharp.MyYumba.StringExtensions;
using static FunctionalCSharp.MyYumba.Y;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap6_PatternsInFunctionalProgramming;

public class Chap6OptionForEachTests
{
    [Fact]
    public void Test_OptionYForEach()
    {
        Optiono<string> empty = Nono;
        var john = Somo("John");

        var emptyGreet = empty.YForEach(WriteLine); // does not write anything
        var johnGreet = john.YForEach(WriteLine); // writes John
    }
    
    [Fact]
    public void Test_YMap_And_YForEach_For_Option_And_IEnumerable()
    {
        Optiono<string> empty = Nono;
        var john = Somo("John");
        
        empty.YMap(x => x.ToUpper()).YForEach(WriteLine);
        john.YMap(x => x.ToUpper()).YForEach(WriteLine); // JOHN
        
        var names = new[] { "Constance", "Albert" };
        names.YMap(YToUpper).YForEach(WriteLine); // CONSTANCE, ALBERT
    }
}
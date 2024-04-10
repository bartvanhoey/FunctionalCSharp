using FunctionalCSharp.MyYumba;
using static System.Console;
using static FunctionalCSharp.MyYumba.YStringExtensions;
using static FunctionalCSharp.MyYumba.Y;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap6_PatternsInFunctionalProgramming;

public class Chap6OptionForEachTests
{
    [Fact]
    public void Test_OptionYForEach()
    {
        YOption<string> empty = YNone;
        var john = YSome("John");

        var emptyGreet = empty.YForEach(WriteLine); // does not write anything
        var johnGreet = john.YForEach(WriteLine); // writes John
    }
    
    [Fact]
    public void Test_YMap_And_YForEach_For_Option_And_IEnumerable()
    {
        YOption<string> empty = YNone;
        var john = YSome("John");
        
        empty.YMap(x => x.ToUpper()).YForEach(WriteLine);
        john.YMap(x => x.ToUpper()).YForEach(WriteLine); // JOHN
        
        var names = new[] { "Constance", "Albert" };
        names.YMap(YToUpper).YForEach(WriteLine); // CONSTANCE, ALBERT
    }
}
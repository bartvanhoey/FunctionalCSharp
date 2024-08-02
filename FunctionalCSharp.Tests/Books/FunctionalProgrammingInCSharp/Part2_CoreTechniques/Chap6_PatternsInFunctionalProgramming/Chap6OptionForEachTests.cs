using FunctionalCSharp.MyYumba;
using LaYumba.Functional;
using static System.Console;
using static FunctionalCSharp.MyYumba.YString;
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
        
        Option<string> optEmpty = F.None;
        var optJohn = F.Some("John");

        optEmpty.ForEach(name => WriteToConsole($"Hello, {name}")); // Nothing will be written to console as Option is None
        optJohn.ForEach(name => WriteToConsole($"Hello, {name}"));

        // EVEN BETTER
        // Wwe should aim to separate pure logic from side effects.
        // We should use Map for logic and ForEach for side effects, so it would be preferable to rewrite the preceding code as follows:
        
        // Map => for the data transformation
        // ForEach => for the side effects
        
        // Follows the general FP idea of avoiding side effects if possible, isolating them otherwise
        
        optEmpty.Map(name => $"Hello {name}").ForEach(WriteToConsole); // Nothing will be written to console as Option is None
        optJohn.Map(name => $"Hello {name}").ForEach(WriteToConsole);
    }
    
    [Fact]
    public void Test_YMap_And_YForEach_For_Option_And_IEnumerable()
    {
        // Notice that you can use the same patterns (MAP/FOREACH), whether you’re working with Option or IEnumerable
        YOption<string> empty = YNone;
        var john = YSome("John");
        
        empty.YMap(YToUpper).YForEach(WriteToConsole);
        john.YMap(YToUpper).YForEach(WriteToConsole); // JOHN
        
        var names = new[] { "Constance", "Albert" };
        names.YMap(YToUpper).YForEach(WriteToConsole); // CONSTANCE, ALBERT
    }
    
    private static void WriteToConsole(string input)
    {
        WriteLine("================================");
        WriteLine(input);
        WriteLine("================================");
    }

}
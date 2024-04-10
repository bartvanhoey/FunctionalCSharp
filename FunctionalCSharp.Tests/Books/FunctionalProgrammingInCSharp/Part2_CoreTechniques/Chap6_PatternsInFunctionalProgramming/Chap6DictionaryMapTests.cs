using FunctionalCSharp.MyYumba;
using Shouldly;
using static FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap6_PatternsInFunctionalProgramming.Chap6Age;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.
    Chap6_PatternsInFunctionalProgramming;

public class Chap6DictionaryMapTests
{
    [Fact]
    public void YMap_IDictionary_Should_Return_Correct_Values()
    {
        var range = Enumerable.Range(1, 10);

        var dicT = new Dictionary<string, int>()
        {
            { "John", 50 },
            { "Marie", 40 },
            { "Tom", 30 }
        };

        var dicR = dicT.YMap(i => $"Is {i} years old");
        dicR.ShouldBe(new Dictionary<string, string>()
        {
            { "John", "Is 50 years old" },
            { "Marie", "Is 40 years old" },
            { "Tom", "Is 30 years old" }
        });
    }
}
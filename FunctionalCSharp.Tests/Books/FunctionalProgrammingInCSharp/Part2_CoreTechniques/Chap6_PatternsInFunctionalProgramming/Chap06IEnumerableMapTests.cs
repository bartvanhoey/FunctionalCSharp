using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap6_PatternsInFunctionalProgramming;
using FunctionalCSharp.MyYumba;
using Shouldly;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap6_PatternsInFunctionalProgramming;

public class Chap06IEnumerableMapTests
{
    [Fact]
    public void TestMyMap()
    {
        var range = Enumerable.Range(1,10);

        var result = range.YMap(x => x * 3);
        
        result.ShouldBe(new List<int> {3,6,9,12,15,18,21,24,27,30});
    }
}
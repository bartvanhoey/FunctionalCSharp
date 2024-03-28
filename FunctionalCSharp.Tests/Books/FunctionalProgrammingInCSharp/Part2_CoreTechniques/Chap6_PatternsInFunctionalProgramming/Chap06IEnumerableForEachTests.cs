using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap6_PatternsInFunctionalProgramming;
using FunctionalCSharp.MyYumba;
using Shouldly;
using static System.Console;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap6_PatternsInFunctionalProgramming;

public class Chap06IEnumerableForEachTests
{
    [Fact]
    public void TestYForeach()
    {
        var range = Enumerable.Range(1,10);
        
        var units = range.YForEach(WriteLine);
    }
}
using FunctionalCSharp.MyYumba;
using Shouldly;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap6_PatternsInFunctionalProgramming;

public class Chap6OptionMapTests
{
    [Fact]
    public void Test_OptionMap()
    {
        var greet = (string name) => $"Hello, {name}";

        YOption<string> empty = Y.YNone;
        YOption<string> john = Y.YSome("John");

        var emptyGreet = empty.YMap(greet);
        emptyGreet.ShouldBe(Y.YNone);
        
        var johnGreet = john.YMap(greet);
        johnGreet.ShouldBe(Y.YSome("Hello, John"));
    }
}
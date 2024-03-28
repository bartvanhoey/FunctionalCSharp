using FunctionalCSharp.MyYumba;
using Shouldly;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap6_PatternsInFunctionalProgramming;

public class Chap6OptionMapTests
{
    [Fact]
    public void Test_OptionMap()
    {
        var greet = (string name) => $"Hello, {name}";

        Optiono<string> empty = Y.Nono;
        Optiono<string> john = Y.Somo("John");

        var emptyGreet = empty.YMap(greet);
        emptyGreet.ShouldBe(Y.Nono);
        
        var johnGreet = john.YMap(greet);
        johnGreet.ShouldBe(Y.Somo("Hello, John"));
    }
}
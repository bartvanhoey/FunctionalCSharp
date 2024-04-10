using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap6_PatternsInFunctionalProgramming;
using FunctionalCSharp.MyYumba;
using Shouldly;
using static FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap6_PatternsInFunctionalProgramming.Chap6Age;
using static FunctionalCSharp.MyYumba.Y;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap6_PatternsInFunctionalProgramming;

public class Chap06PopulationSurveyTests
{
    // public record Chap6Subject(yOption<Chap6Age> Age, yOption<Chap6Gender> Gender);
    
    [Fact]
    public void Test_RiskOf_Method()
    {
        var population = new[]
        {
            new Chap6Subject(CreateAge(33), YNone),
            new Chap6Subject(YNone, YNone),
            new Chap6Subject(CreateAge(37), YNone),
        };

        var mapAges = population.YMap(x => x.Age);

        var statedAges = population.YBind(x => x.Age);
        var average = statedAges.YMap(age => age.Value).Average();
        average.ShouldBe(35);
    }
}
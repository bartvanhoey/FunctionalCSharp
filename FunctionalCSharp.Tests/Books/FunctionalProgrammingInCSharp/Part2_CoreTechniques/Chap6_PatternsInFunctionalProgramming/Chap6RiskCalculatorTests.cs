using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap6_PatternsInFunctionalProgramming;
using FunctionalCSharp.MyYumba;
using Shouldly;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap6_PatternsInFunctionalProgramming;

public class Chap6RiskCalculatorTests
{
    [Fact]
    public void Test_RiskOf_Method()
    {
        var subject1 = new Chap6Subject(Chap6Age.CreateAge(50), Chap6Gender.Female);
        var riskOf = Chap6RiskCalculator.RiskOf(subject1);
        var risk = riskOf.YMatch(() => "" , x => x.ToString());
        risk.ShouldBe(Chap6Risk.Low.ToString());
    }
    
    [Fact]
    public void Test_RiskOf_Method1()
    {
        var subject1 = new Chap6Subject(Y.YNone, Chap6Gender.Female);
        var riskOf = Chap6RiskCalculator.RiskOf(subject1);
        var risk = riskOf.YMatch(() => "" , x => x.ToString());
        risk.ShouldBe("");
    }
    
    
}
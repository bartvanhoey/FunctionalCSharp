using FluentAssertions;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap4_FunctionSignaturesAndTypes;
using static FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap4_FunctionSignaturesAndTypes.Chap4Age;
using static FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap4_FunctionSignaturesAndTypes.RiskCalculatorChap4;
using static Xunit.Assert;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap4_FunctionSignaturesAndTypes;

public class RiskCalculatorChap4Tests
{
    [Theory]
    [InlineData(0, RiskChap4.Low)]
    [InlineData(20, RiskChap4.Low)]
    [InlineData(59, RiskChap4.Low)]
    [InlineData(60, RiskChap4.Medium)]
    [InlineData(120, RiskChap4.Medium)]
    public void RiskProfileCalculator(int age, RiskChap4 riskChap4) 
        => CalculateRiskProfileChap4(CreateAge(age)).Should().Be(riskChap4);

    [Theory]
    [InlineData(200, RiskChap4.Medium)]
    [InlineData(-1, RiskChap4.Medium)]
    [InlineData(121, RiskChap4.Medium)]
    public void RiskProfileCalculator1(int age, RiskChap4 riskChap4) 
        => Throws<ArgumentOutOfRangeException>(() => CalculateRiskProfileChap4(CreateAge(age)).Should().Be(riskChap4));

    [Theory]
    [InlineData("ABCDEFGJ123",true)]
    [InlineData(null, false)]
    public void Method_OptionTestMethod_ShouldReturn(string value, bool expected)
    {
        var result = new Chap4().OptionTestMethod(value);
        result.IsSome.Should().Be(expected);
    }
        

    
}
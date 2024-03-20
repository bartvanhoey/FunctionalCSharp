using FluentAssertions;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap4_FunctionSignaturesAndTypes;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap4_FunctionSignaturesAndTypes.CustomType;
using static FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap4_FunctionSignaturesAndTypes.RiskCalculator;
using static Xunit.Assert;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap4_FunctionSignaturesAndTypes;

public class RiskCalculatorTests
{
    [Theory]
    [InlineData(0, Risk.Low)]
    [InlineData(20, Risk.Low)]
    [InlineData(59, Risk.Low)]
    [InlineData(60, Risk.Medium)]
    [InlineData(120, Risk.Medium)]
    public void RiskProfileCalculator(int age, Risk risk) 
        => CalculateRiskProfile(Age.CreateAge(age)).Should().Be(risk);

    [Theory]
    [InlineData(200, Risk.Medium)]
    [InlineData(-1, Risk.Medium)]
    [InlineData(121, Risk.Medium)]
    public void RiskProfileCalculator1(int age, Risk risk) 
        => Throws<ArgumentOutOfRangeException>(() => CalculateRiskProfile(Age.CreateAge(age)).Should().Be(risk));

    [Theory]
    [InlineData("ABCDEFGJ123",true)]
    [InlineData(null, false)]
    public void Method_OptionTestMethod_ShouldReturn(string value, bool expected)
    {
        var result = new Chap4().OptionTestMethod(value);
        result.IsSome.Should().Be(expected);
    }
        

    
}
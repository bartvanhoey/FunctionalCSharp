using FluentAssertions;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap4_FunctionSignaturesAndTypes;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap4_FunctionSignaturesAndTypes.CustomType;
using static System.IO.File;
using static System.IO.Path;
using static System.Reflection.Assembly;
using static System.Text.Encoding;
using static FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap4_FunctionSignaturesAndTypes.Instrumentation;
using static FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap4_FunctionSignaturesAndTypes.RiskCalculator;
using static Xunit.Assert;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap4_FunctionSignaturesAndTypes;

public class Chap4Tests
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


    [Fact]
    public void MethodTime_When_Executing_FileReadAllText_ShouldReturn_NotNull()
    {
        var file = GetFilePath("file.txt");
        var result = WriteTimeTakenToConsole("Reading from file.txt", () => ReadAllText(file));
        result.Should().NotBeNull();
    }
        
    [Fact]
    public void MethodTime_When_Executing_FileAppendText_ShouldReturn_NotNull()
    {
        var file = GetFilePath("file.txt");
        WriteTimeTakenToConsole("Reading from file.txt", () => AppendAllText(file, "Hello World", UTF8));
    }
        
    [Theory]
    [InlineData("ABCDEFGJ123",true)]
    [InlineData(null, false)]
    public void Method_OptionTestMethod_ShouldReturn(string value, bool expected)
    {
        var result = new Chap4().OptionTestMethod(value);
        result.IsSome.Should().Be(expected);
    }
        

    private static string GetFilePath(string fileName) 
        => Combine(GetDirectoryName(GetExecutingAssembly().Location) ?? throw new InvalidOperationException(), fileName);
}
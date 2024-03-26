using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.
    Chap5_DesigningProgramsWithFunctionComposition.CustomType;
using Shouldly;
using static Xunit.Assert;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_ModellingDataAbsence;

public class AgeChap5Tests
{
    [Theory]
    [InlineData(200)]
    [InlineData(-1)]
    [InlineData(121)]
    public void AgeChap5_CreateAge_Should_Not_Create_Valid_Ages_When_Invalid_Inputs_Provided(int age)
    {
        var optiono = AgeChap5.CreateAge(age);
        Throws<ArgumentOutOfRangeException>(() =>
            optiono.Match<int>(() => throw new ArgumentOutOfRangeException(), x => x));
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(30, 30)]
    [InlineData(60, 60)]
    [InlineData(90, 90)]
    [InlineData(119, 119)]
    public void AgeChap5_CreateAge_Should_Create_Valid_Ages_When_Valid_Inputs_Provided(int age, int resultAge)
    {
        var optiono = AgeChap5.CreateAge(age);

        var result = optiono.Match<int>(() => throw new ArgumentOutOfRangeException(), x => x);
        
        result.ShouldBe(resultAge);
    }
}
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap2_ThinkingInFunctions;
using FluentAssertions;
using Shouldly;
using static System.DayOfWeek;


namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap2_ThinkingInFunctions;

public class Chap2Tests
{

    [Fact]
    public void Method_GetDaysStartingWith_Should_Return_Correct_Days()
    {
        var chap3 = new Chap02();

        var sunday = chap3.GetDaysStartingWith("Su")?.FirstOrDefault();
        sunday.Should().Be(Sunday);
            
        var monday = chap3.GetDaysStartingWith("Mo")?.FirstOrDefault();
        monday.Should().NotBe(Sunday);
        monday.Should().Be(Monday);
            
        var notExisting = chap3.GetDaysStartingWith("Ti")?.FirstOrDefault();
        notExisting.ShouldBeNull();
    }
}
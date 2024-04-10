using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap2_ThinkingInFunctions;
using Shouldly;
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
        sunday.ShouldBe(Sunday);
            
        var monday = chap3.GetDaysStartingWith("Mo")?.FirstOrDefault();
        monday.ShouldNotBe(Sunday);
        monday.ShouldBe(Monday);
            
        var notExisting = chap3.GetDaysStartingWith("Ti")?.FirstOrDefault();
        notExisting.ShouldBeNull();
    }
}
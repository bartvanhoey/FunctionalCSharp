using Shouldly;

namespace FunctionalCSharp.Tests.Functional.LinqExpressions.Cast;

public class CastTests
{
    [Fact]
    public void Method_Aggregate_On_A_List_Of_Integers_Should_Return_Correct_Sum()
    {
        var days = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>().ToList();
        // days.Should .HaveCount(7);
        days.FirstOrDefault().ShouldBe(DayOfWeek.Sunday) ;
    }
}
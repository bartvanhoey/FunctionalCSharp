using FluentAssertions;
using static FunctionalCSharp.Courses.MoreEffectiveLinq.Module4CleanAndReadableCode.CleanAndReadableLinqCode;

namespace FunctionalCSharp.Tests.Courses.MoreEffectiveLinq.Module4CleanAndReadableCode;

public class CleanAndReadableLinqCodeTests
{
    [Fact]
    public void Method_GetPlayerAge_Should_Return_Name_And_Age_Youngest_Player()
    {
        var players =
            "Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; Kelvin Davis, 29/09/1976; Luke Shaw, 12/07/1995; Gaston Ramirez, 02/12/1990; Adam Lallana, 10/05/1988";

        var playerAges = GetPlayerAge(players);
        playerAges.First().Name.Should().Be("Luke Shaw");
    }
}
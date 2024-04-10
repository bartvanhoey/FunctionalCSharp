using Shouldly;
using static FunctionalCSharp.Courses.MoreEffectiveLinq.Module4CleanAndReadableCode.BookWithMostPagesChallenge;

namespace FunctionalCSharp.Tests.Courses.MoreEffectiveLinq.Module4CleanAndReadableCode;

public class BookWithMostPagesTests
{

    [Fact]
    public void Method_FindBookWithMostPages_Should_Return_Book_With_Most_Pages()
    {
        var result = FindBookWithMostPages();
        result.ShouldBe("Patterns of Enterprise Application Architecture");

    }

}
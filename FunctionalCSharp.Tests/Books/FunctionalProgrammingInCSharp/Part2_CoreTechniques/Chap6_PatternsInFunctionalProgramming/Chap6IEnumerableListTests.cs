using Shouldly;
using static FunctionalCSharp.MyYumba.EnumerableExtensions;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap6_PatternsInFunctionalProgramming;

public class Chap6IEnumerableListTests
{
    [Fact]
    public void Test_YList_IEnumerable()
    {
        var emptyList = YList<string>();
        var listOneItem = YList("Andrej");
        var listTwoItems = YList("Katarina", "Natasha");
        
        emptyList.ShouldBe([]);
        listOneItem.ShouldBe(["Andrej"]);
        listTwoItems.ShouldBe(["Katarina","Natasha"]);
    }
}
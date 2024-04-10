using FunctionalCSharp.MyYumba;
using LaYumba.Functional;
using Shouldly;
using static FunctionalCSharp.MyYumba.Y;
using static FunctionalCSharp.MyYumba.YInt;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap6_PatternsInFunctionalProgramming;

public class Chap6YOptionWhereTests
{
    private static  bool IsNatural(int i) => i >= 0;
    private static YOption<int> ToNatural(string s) => YIntParse(s).YWhere(IsNatural);
    
    [Fact]
    public void Test_YWhere_yOption()
    {
        ToNatural("2").ShouldBe(YSome(2));    
        ToNatural("-2").ShouldBe(YNone);    
        ToNatural("hello").ShouldBe(YNone);    
    }

}
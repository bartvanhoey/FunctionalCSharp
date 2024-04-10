using FunctionalCSharp.MyYumba;
using static FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap6_PatternsInFunctionalProgramming.Chap6Age;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap6_PatternsInFunctionalProgramming;

public class Chap6OptionBindTests
{
    [Fact]
    public void TestOptionBindTest()
    {
        var age = "20";

        var optInteger = YInt.YIntParse(age);
        
        // YMap yOption<R> YMap<T, R>(this yOption<T> yOption, Func<T, R> func)
        // Map takes a regular function
        // YMap (yOption<T>, (T -> R)) -> yOption<R>
        // YMap and CreateAge both create an yOption => yOption<yOption<Chap6Age>>
        
        var yOptionyOptionChap6Age = optInteger.YMap(CreateAge);
        
        // In this case use YBind
        // Bind takes an Option-returning function
        // (Option<T>, (T -> Option<R>)) -> Option<R>

        var yOptionChap6Age = optInteger.YBind(CreateAge);
    }
}
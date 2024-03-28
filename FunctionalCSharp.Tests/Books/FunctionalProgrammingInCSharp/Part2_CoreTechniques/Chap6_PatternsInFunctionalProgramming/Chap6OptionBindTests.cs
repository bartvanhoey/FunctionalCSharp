using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap4_FunctionSignaturesAndTypes;
using FunctionalCSharp.MyYumba;
using Fupr;
using LaYumba.Functional;
using static FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap6_PatternsInFunctionalProgramming.Chap6Age;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap6_PatternsInFunctionalProgramming;

public class Chap6OptionBindTests
{
    [Fact]
    public void TestOptionBindTest()
    {
        var age = "20";

        var optInteger = YInt.YParse(age);
        
        // YMap Optiono<R> YMap<T, R>(this Optiono<T> optiono, Func<T, R> func)
        // Map takes a regular function
        // YMap (Optiono<T>, (T -> R)) -> Optiono<R>
        // YMap and CreateAge both create an Optiono => Optiono<Optiono<Chap6Age>>
        
        var optionoOptionoChap6Age = optInteger.YMap(CreateAge);
        
        // In this case use YBind
        // Bind takes an Option-returning function
        // (Option<T>, (T -> Option<R>)) -> Option<R>

        var optionoChap6Age = optInteger.YBind(CreateAge);
    }
}
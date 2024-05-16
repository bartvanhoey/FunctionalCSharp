using FunctionalCSharp.MyYumba;
using Shouldly;
using static System.Math;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part3_FunctionalDesigns.Chap8_FunctionalErrorHandling;

public class Chap8Tests
{
    [Theory]
    [InlineData(-3, -3, "The result is: 1")]
    [InlineData(3, 0, "Invalid value: y cannot be 0")]
    [InlineData(3, -3, "Invalid value: x/y cannot be negative")]
    public void Test_Either_Returning_Calculate_Method(double x, double y, string result) 
        => Calculate(x, y).RenderResult().ShouldBe(result);

    private static YEither<string, double> Calculate(double x, double y)
    {
        if (y == 0) return "y cannot be 0";
        if (y != 0 && Sign(x) != Sign(y)) return "x/y cannot be negative";
        return Sqrt(x / y);
    }
    
}





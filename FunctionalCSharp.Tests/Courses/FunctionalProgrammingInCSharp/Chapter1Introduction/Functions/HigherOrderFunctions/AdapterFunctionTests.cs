using FluentAssertions;
using FunctionalCSharp.Courses.FunctionalProgrammingInCSharp.Chapter1Introduction.Functions.HigherOrderFunctions;

namespace FunctionalCSharp.Tests.Courses.FunctionalProgrammingInCSharp.Chapter1Introduction.Functions.HigherOrderFunctions
{
    public class AdapterFunctionTests
    {
        [Fact]
        public void Test_DivideMethod()
        {
            var result = AdapterFunctions.Divide(10, 5);
            result.Should().Be(2);
        }
        
        [Fact]
        public void Test_Applying_SwapArgs_Extension_Method_On_DivideMethod_Should_Divide_With_Swapped_Arguments()
        {
            var divideSwapped = AdapterFunctions.Divide.SwapArgs();
            var result= divideSwapped(5, 10);
            result.Should().Be(2);
        }
    }
}
using FluentAssertions;
using static System.Linq.Enumerable;
using static FunctionalCSharp.Courses.FunctionalProgrammingInCSharp.Chapter1Introduction.Functions.FunctionFactories.FunctionFactory;

namespace FunctionalCSharp.Tests.Courses.FunctionalProgrammingInCSharp.Chapter1Introduction.Functions.FunctionFactories
{
    public class FunctionFactoryTests
    {
        [Fact]
        public void TestIsModFunction()
        {
            var divisibleBy2 = Range(1, 20).Where(IsDivisibleBy(2)).ToList();
            var divisibleBy3 = Range(1, 20).Where(IsDivisibleBy(3)).ToList();


            divisibleBy2.Should().Contain(4);
            divisibleBy3.Should().Contain(9);

        }
    }
}
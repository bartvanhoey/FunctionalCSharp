using Shouldly;
using static FunctionalCSharp.Courses.FunctionalProgrammingWithCSharp.Module3_FunctionalThinking.Calculator;

namespace FunctionalCSharp.Tests.Courses.FunctionalProgrammingWithCSharp.Module3_FunctionalThinking
{
    public class CalculatorTests
    {
        [Fact]
        public void Method_Eval_Should_Return_Correct_Results()
        {
            Eval("1 3 +").ShouldBe(4);
            Eval("10 5 -").ShouldBe(5);
            Eval("2 3 *").ShouldBe(6);
            Eval("14 2 /").ShouldBe(7);
        }
    }
}
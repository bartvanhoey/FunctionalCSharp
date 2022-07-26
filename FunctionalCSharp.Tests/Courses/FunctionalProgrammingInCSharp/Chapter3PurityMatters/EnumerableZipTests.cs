using FluentAssertions;
using static FunctionalCSharp.Courses.FunctionalProgrammingInCSharp.Chapter2PurityMatters.MyEnumerable;

namespace FunctionalCSharp.Tests.Courses.FunctionalProgrammingInCSharp.Chapter3PurityMatters
{
    public class EnumerableZipTests
    {
        [Fact]
        public void EnumerableZip_Should_Return_Correct_Result()
        {
            var ints = new[] { 1, 2, 3 };
            var strings = new[] { "one", "two", "tree" };
            
            var items = Zip(ints, strings);

            items.Should().Contain("In English, 1 is: one");
        }

        

    }
}
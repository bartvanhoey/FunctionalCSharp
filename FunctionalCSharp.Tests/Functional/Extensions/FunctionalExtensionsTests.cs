using FluentAssertions;
using FunctionalCSharp.Extensions;

namespace FunctionalCSharp.Tests.Functional.Extensions
{
    public class FunctionalExtensionsTests
    {
        [Fact]
        public void TestMapFunctionalExtension()
        {
            Func<int, int> multiplyByTree = x => x * 3;

            var list = Enumerable.Range(1, 3)
                .Map(x => x * 3).ToList();

            list.Should().Contain(3);
            list.Should().Contain(6);
            list.Should().Contain(9);
            
        }
    }
}
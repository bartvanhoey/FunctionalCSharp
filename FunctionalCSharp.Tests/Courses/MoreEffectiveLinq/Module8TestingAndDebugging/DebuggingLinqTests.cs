using Shouldly;
using static FunctionalCSharp.Courses.MoreEffectiveLinq.Module8TestingAndDebugging.DebuggingLinq;

namespace FunctionalCSharp.Tests.Courses.MoreEffectiveLinq.Module8TestingAndDebugging;

public class DebuggingLinqTests
{
    [Fact]
    public void Test_PeekMethodExample()
    {
        var result = PeekMethodExample();
        result.ShouldBe(440);
    }
        
    [Fact]
    public void Test_TrySelectExample()
    {
        var list = TrySelectExample();
            
    }

    [Theory]
    [InlineData(new int[] { }, new int[] { })]
    [InlineData(new[] { 1 }, new int[] { })]
    [InlineData(new[] { 10 }, new[] { 45 })]
    [InlineData(new[] { 6 }, new[] { 13 })]
    [InlineData(new[] { 10, 6 }, new[] { 45, 13 })]
    [InlineData(new[] { 6, 10 }, new[] { 45, 13 })]
    public void Test_ConvertNumbers(int[] inputSequence, int[] outputSequence)
    {
        var result = ConvertNumbers(inputSequence);
        result.ShouldBe(outputSequence);
    }
}
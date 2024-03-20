using System.Diagnostics;
using static FunctionalCSharp.Courses.MakingYourCSharpCodeMoreFunctional.Memoization.Memoization;

namespace FunctionalCSharp.Tests.Courses.MakingYourCSharpCodeMoreFunctional.Memoization;

public class MemoizationTests
{
    private static void Execute(Func<int, long> fibonacci, int offset =1)
    {
        for (var i = 0; i < 10; i++) 
            Debug.Print($"{offset+i}\t{fibonacci(offset+i)}");
    }

    [Fact]
    public void TestNaiveFibonacci() => Execute(NaiveFibonacci);
        
    [Fact]
    public void TestDynamicFibonacci() => Execute(DynamicFibonacci, 50);
        
    [Fact]
    public void TestForwardFibonacci() => Execute(ForwardFibonacci, 50);

        
}